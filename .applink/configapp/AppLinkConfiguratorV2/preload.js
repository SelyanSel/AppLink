const { contextBridge, ipcRenderer } = require('electron')

contextBridge.exposeInMainWorld('extapp', {
    openRepo: () => ipcRenderer.send('open-repo'),
    issueRepo: () => ipcRenderer.send('issue-repo'),
    starRepo: () => ipcRenderer.send('star-repo')
})

window.addEventListener('DOMContentLoaded', () => {
    const replaceText = (selector, text) => {
        const element = document.getElementById(selector)
        if (element) element.innerText = text
    }

    for (const type of ['chrome', 'node', 'electron']) {
        replaceText(`${type}-version`, process.versions[type])
    }
})