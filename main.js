var express = require('express');
var app = express();
var fs = require('fs');
var bodyParser = require('body-parser');
var pjson = require('./package.json');

require('dotenv').config();

var jsonParser = bodyParser.json()

var enableCommandExecution = process.env.enableCommandExecution === "true"
var restrictCommandExecution = process.env.restrictCommandExecution === "true"

var stopPass = process.env.stopPassword

var applications

function shutdownServer(){
    console.log('\n\x1b[34m>>> AppLink Server v' + pjson.version + ' stopping...\x1b[0m\n')
    process.exit();
}

function logConsole(content){
    console.log('\x1b[34m>>> \x1b[33m[LOG] \x1b[32m' + content + ' \x1b[0m')
    return;
}

fs.readFile('./apps/appsRegistery.json', 'utf8', (err, data) => {
    if (err) {
      console.error(err);
      return;
    }
    applications = JSON.parse(data);
});

app.get('/api/openApp', async (req,res) => {

    let appname = req.query.name;

    applications['apps'].forEach(obj => {
        if (obj['name'] === appname) {
            var exec = require('child_process').exec;
            exec(obj['path']);
        }
    });

    applications['commands'].forEach(obj => {
        if (obj['name'] === appname) {
            var exec = require('child_process').exec;
            exec(obj['exec']);
        }
    });

    res.status(200).send(JSON.stringify({status:"ok"}))
});

app.get('/api/execCommand', async (req,res) => {
    let appname = req.query.command
    var foundApp = false

    if (enableCommandExecution === true) {
        if (restrictCommandExecution === true)
        {
            applications['commands'].forEach(obj => {
                if (obj['name'] === appname) {
                    var exec = require('child_process').exec;
                    exec(obj['exec']);
                    foundApp = true
                }
            });
        }else{
            foundApp = true
            var exec = require('child_process').exec;
            console.log('cmd /c "' + appname + '"')
            exec('cmd /c "' + appname + '"');
        }
        
        if (foundApp) {
            res.status(200).send(JSON.stringify({status:"ok"}))
            logConsole('Remote command execution executed: ' + appname)
        }else{
            res.status(401).send(JSON.stringify({status:"Unknown command or app."}))
            logConsole('Remote command execution stopped: Unknown command or app.')
        }

    }else{

        res.status(401).send(JSON.stringify({status:"Command execution is disabled on this server."}))
        logConsole('Remote command execution stopped: enableCommandExecution is disabled.')

    }
})

app.get('/api/stopServer', async (req,res) =>{
    let pass = req.query.pass

    if (pass === stopPass){
        res.status(200).send(JSON.stringify({status:"Server stopped."}))
        logConsole('Remote stop command executing...')
        shutdownServer();
    }else{
        res.status(401).send(JSON.stringify({status:"Unauthorized."}))
        logConsole('Remote stop command aborted: wrong password')
    }
})

app.use(express.static(__dirname + "/web/"));

app.listen(9989, function() {
    console.log('\n\x1b[34m>>> AppLink Server v' + pjson.version + ' started.\x1b[0m\n')
});