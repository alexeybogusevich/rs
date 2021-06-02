from PyQt5 import QtWidgets, QtGui
from choosepatient_ui import Ui_ChoosePatient
from intro import IntroWidget
import json
import requests

class ChoosePatientsWidget(QtWidgets.QWidget):
    def __init__(self, token=None):
        super(ChoosePatientsWidget, self).__init__()
        
        if (token is None):
            sys.exit(app.exec_())
        
        self.token = token

        self.ui = Ui_ChoosePatient()
        self.ui.setupUi(self)
        
        PATIENTS_ENDPOINT = "https://app-knu-rs-westeu-002.azurewebsites.net/api/patients"
        patientsResponse = requests.get(PATIENTS_ENDPOINT, headers={'Authorization': 'Bearer ' + token})
        
        #STYPES_ENDPOINT = "https://app-knu-rs-westeu-002.azurewebsites.net/api/studytypes"
        #studyTypesResponse = requests.get(STYPES_ENDPOINT, headers={'Authorization': 'Bearer ' + token})
        
        if (patientsResponse.status_code == 403):
            msg = QtWidgets.QMessageBox()
            msg.setIcon(QtWidgets.QMessageBox.Critical)
            msg.setText("У вас немає доступу до інформації про пацієнтів та інструменту діагностики.")
            msg.setStandardButtons(QtWidgets.QMessageBox.Ok)
            msg.exec_()
            sys.exit(app.exec_())
        
        if (patientsResponse.text is None):
            msg = QtWidgets.QMessageBox()
            msg.setIcon(QtWidgets.QMessageBox.Critical)
            msg.setText("Сталась помилка. Зверніться до адміністратора.")
            msg.setStandardButtons(QtWidgets.QMessageBox.Ok)
            msg.exec_()
            sys.exit(app.exec_())
        
        self.selectedPatientIndex = 0
        #self.selectedStudyIndex = 0

        patients = json.loads(patientsResponse.text)
        #studyTypes = json.loads(studyTypesResponse.text)
        
        if (len(patients) == 0):
            msg = QtWidgets.QMessageBox()
            msg.setIcon(QtWidgets.QMessageBox.Critical)
            msg.setText("За вами не закріплено пацієнтів. Зверніться до адміністратора системи.")
            msg.setStandardButtons(QtWidgets.QMessageBox.Ok)
            msg.exec_()
            sys.exit(app.exec_())
        
        self.ui.comboBox_patient.clear()
        self.ui.comboBox_study.clear()

        for patient in patients:
            self.ui.comboBox_patient.addItem(patient["fullName"], patient["id"])
            
        self.ui.comboBox_study.addItem("Обстеження шийного відділу", "1")
            
        self.ui.comboBox_patient.activated.connect(self.handlePatientActivated)        
        self.ui.pushButton.clicked.connect(self.observePatient)
        
    def handlePatientActivated(self, index):
        self.selectedPatientIndex = index
        print(self.selectedPatientIndex)
        print(self.ui.comboBox_patient.itemText(index))
        print(self.ui.comboBox_patient.itemData(index))
        
    def observePatient(self):
        selectedPatientId = self.ui.comboBox_patient.itemData(self.selectedPatientIndex)
        self.window = IntroWidget(selectedPatientId, self.token)
        self.window.show()
        self.window.destroyed.connect(self.showAgain)
        self.setVisible(False)
        
    def showAgain(self):
        self.setVisible(True)

    def closeEvent(self, a0: QtGui.QCloseEvent) -> None:
        QtWidgets.QApplication.quit()
        
if __name__ == "__main__":
    import sys

    app = QtWidgets.QApplication(sys.argv)
    widget = ChoosePatientsWidget()
    widget.show()
    app.exec()
