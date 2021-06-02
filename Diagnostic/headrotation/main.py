#  !/usr/bin/env python
#
#  Created by Dmytro Kotsur on 9/19/19, 9:13 PM.
#  Copyright (c) 2019 Dmytro Kotsur. All rights reserved.

import sys
from PyQt5 import QtWidgets
from login import LoginWidget


def main():
    app = QtWidgets.QApplication(sys.argv)
    app.setQuitOnLastWindowClosed(False)
    login = LoginWidget()
    login.show()
    sys.exit(app.exec_())


if __name__ == "__main__":
    main()
