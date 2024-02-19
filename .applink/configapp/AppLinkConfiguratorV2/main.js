const { app, BrowserWindow, ipcMain } = require('electron')
const { execSync } = require('node:child_process')
const path = require('node:path')

function createWindow () {
    const win = new BrowserWindow({
        width: 1200,
        height: 600,
        maximizable:false,
        resizable:false,
        autoHideMenuBar:true,
        backgroundColor:'#010409',
        webPreferences: {
            preload: path.join(__dirname, 'preload.js')
        }
    })

    ipcMain.on('issue-repo', (event, title) => {
        execSync("start https://github.com/SelyanSel/AppLink/issues")
    })

    ipcMain.on('open-repo', (event, title) => {
        execSync("start https://github.com/SelyanSel/AppLink")
    })

    ipcMain.on('star-repo', (event, title) => {
        execSync("start https://github.com/SelyanSel/AppLink")
    })

    win.loadFile('./src/index.html')
}

app.whenReady().then(() => {
    createWindow()

    app.on('activate', () => {
        if (BrowserWindow.getAllWindows().length === 0) {
            createWindow()
        }
    })
})

app.on('window-all-closed', () => {
    if (process.platform !== 'darwin') {
        app.quit()
    }
})