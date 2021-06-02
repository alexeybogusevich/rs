from PyQt5 import QtWidgets, QtGui
from login_ui import Ui_Dialog
from choosepatient import ChoosePatientsWidget
import requests

class LoginWidget(QtWidgets.QWidget):
    def __init__(self):
        super(LoginWidget, self).__init__()
        
        self.ui = Ui_Dialog()
        self.ui.setupUi(self)
        
        self.ui.pushButton.clicked.connect(self.tryLogin)
        
    def tryLogin(self):
        mail = self.ui.loginEdit.text()
        password = self.ui.passwordEdit.text()
        
        body = {'email':mail, 'password':password}
        LOGIN_ENDPOINT = "https://app-knu-rs-westeu-002.azurewebsites.net/api/authentication"
        
        r = requests.post(url = LOGIN_ENDPOINT, json = body)
        print(r)
        
        if (r.status_code != 200):
            msg = QtWidgets.QMessageBox()
            msg.setIcon(QtWidgets.QMessageBox.Critical)
            msg.setText("Невірно введений Email або пароль.")
            msg.setStandardButtons(QtWidgets.QMessageBox.Ok)
            msg.exec_()
        else:
            self.window = ChoosePatientsWidget(r.content.decode('UTF-8'))
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
    widget = LoginWidget()
    widget.show()
    sys.exit(app.exec_())