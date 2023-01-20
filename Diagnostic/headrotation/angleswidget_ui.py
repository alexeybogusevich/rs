# -*- coding: utf-8 -*-

# Form implementation generated from reading ui file 'angles.ui'
#
# Created by: PyQt5 UI code generator 5.13.0
#
# WARNING! All changes made in this file will be lost!


from PyQt5 import QtCore, QtGui, QtWidgets


class Ui_Form(object):
    def setupUi(self, Form):
        Form.setObjectName("Form")
        Form.resize(1028, 80)
        Form.setMinimumSize(QtCore.QSize(0, 80))
        Form.setMaximumSize(QtCore.QSize(16777215, 120))
        self.horizontalLayout_4 = QtWidgets.QHBoxLayout(Form)
        self.horizontalLayout_4.setContentsMargins(0, 0, 0, 0)
        self.horizontalLayout_4.setObjectName("horizontalLayout_4")
        self.horizontalLayout = QtWidgets.QHBoxLayout()
        self.horizontalLayout.setObjectName("horizontalLayout")
        spacerItem = QtWidgets.QSpacerItem(40, 20, QtWidgets.QSizePolicy.Expanding, QtWidgets.QSizePolicy.Minimum)
        self.horizontalLayout.addItem(spacerItem)
        self.widgetPitch = RangeWidget(Form)
        self.widgetPitch.setMinimumSize(QtCore.QSize(120, 0))
        self.widgetPitch.setMaximumSize(QtCore.QSize(16777215, 80))
        self.widgetPitch.setObjectName("widgetPitch")
        self.horizontalLayout.addWidget(self.widgetPitch)
        self.label = QtWidgets.QLabel(Form)
        self.label.setMinimumSize(QtCore.QSize(80, 80))
        self.label.setMaximumSize(QtCore.QSize(80, 80))
        self.label.setText("")
        self.label.setPixmap(QtGui.QPixmap(":/icons/icons/1_small.png"))
        self.label.setScaledContents(True)
        self.label.setObjectName("label")
        self.horizontalLayout.addWidget(self.label)
        self.labePitch = QtWidgets.QLabel(Form)
        self.labePitch.setMinimumSize(QtCore.QSize(110, 0))
        self.labePitch.setMaximumSize(QtCore.QSize(110, 16777215))
        font = QtGui.QFont()
        font.setPointSize(20)
        self.labePitch.setFont(font)
        self.labePitch.setTextFormat(QtCore.Qt.RichText)
        self.labePitch.setObjectName("labePitch")
        self.horizontalLayout.addWidget(self.labePitch)
        self.horizontalLayout_4.addLayout(self.horizontalLayout)
        self.horizontalLayout_2 = QtWidgets.QHBoxLayout()
        self.horizontalLayout_2.setObjectName("horizontalLayout_2")
        self.widgetRoll = RangeWidget(Form)
        self.widgetRoll.setMinimumSize(QtCore.QSize(120, 0))
        self.widgetRoll.setMaximumSize(QtCore.QSize(16777215, 80))
        self.widgetRoll.setObjectName("widgetRoll")
        self.horizontalLayout_2.addWidget(self.widgetRoll)
        self.label_2 = QtWidgets.QLabel(Form)
        self.label_2.setMinimumSize(QtCore.QSize(80, 80))
        self.label_2.setMaximumSize(QtCore.QSize(80, 80))
        self.label_2.setText("")
        self.label_2.setPixmap(QtGui.QPixmap(":/icons/icons/2_small.png"))
        self.label_2.setScaledContents(True)
        self.label_2.setObjectName("label_2")
        self.horizontalLayout_2.addWidget(self.label_2)
        self.labeRoll = QtWidgets.QLabel(Form)
        self.labeRoll.setMinimumSize(QtCore.QSize(110, 0))
        self.labeRoll.setMaximumSize(QtCore.QSize(110, 16777215))
        font = QtGui.QFont()
        font.setPointSize(20)
        self.labeRoll.setFont(font)
        self.labeRoll.setTextFormat(QtCore.Qt.RichText)
        self.labeRoll.setObjectName("labeRoll")
        self.horizontalLayout_2.addWidget(self.labeRoll)
        self.horizontalLayout_4.addLayout(self.horizontalLayout_2)
        self.horizontalLayout_3 = QtWidgets.QHBoxLayout()
        self.horizontalLayout_3.setObjectName("horizontalLayout_3")
        self.widgetYaw = RangeWidget(Form)
        self.widgetYaw.setMinimumSize(QtCore.QSize(120, 0))
        self.widgetYaw.setMaximumSize(QtCore.QSize(16777215, 80))
        self.widgetYaw.setObjectName("widgetYaw")
        self.horizontalLayout_3.addWidget(self.widgetYaw)
        self.label_3 = QtWidgets.QLabel(Form)
        self.label_3.setMinimumSize(QtCore.QSize(80, 80))
        self.label_3.setMaximumSize(QtCore.QSize(80, 80))
        self.label_3.setText("")
        self.label_3.setPixmap(QtGui.QPixmap(":/icons/icons/3_small.png"))
        self.label_3.setScaledContents(True)
        self.label_3.setObjectName("label_3")
        self.horizontalLayout_3.addWidget(self.label_3)
        self.labeYaw = QtWidgets.QLabel(Form)
        self.labeYaw.setMinimumSize(QtCore.QSize(110, 0))
        self.labeYaw.setMaximumSize(QtCore.QSize(110, 16777215))
        font = QtGui.QFont()
        font.setPointSize(20)
        self.labeYaw.setFont(font)
        self.labeYaw.setTextFormat(QtCore.Qt.RichText)
        self.labeYaw.setObjectName("labeYaw")
        self.horizontalLayout_3.addWidget(self.labeYaw)
        spacerItem1 = QtWidgets.QSpacerItem(40, 20, QtWidgets.QSizePolicy.Expanding, QtWidgets.QSizePolicy.Minimum)
        self.horizontalLayout_3.addItem(spacerItem1)
        self.horizontalLayout_4.addLayout(self.horizontalLayout_3)

        self.retranslateUi(Form)
        QtCore.QMetaObject.connectSlotsByName(Form)

    def retranslateUi(self, Form):
        _translate = QtCore.QCoreApplication.translate
        Form.setWindowTitle(_translate("Form", "Form"))
        self.labePitch.setText(_translate("Form", "1 градусів"))
        self.labeRoll.setText(_translate("Form", "1 градусів"))
        self.labeYaw.setText(_translate("Form", "1 градусів"))
        
from rangewidget import RangeWidget
import angleswidget_res