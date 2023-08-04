var express = require('express');
var app = express();
var fs = require('fs');
var pjson = require('./package.json');

require('dotenv').config();

var enableCommandExecution = process.env.enableCommandExecution === "true"
var restrictCommandExecution = process.env.restrictCommandExecution === "true"
var requirePassword = process.env.requirePassword === "true"

var accessPass = process.env.accessPassword

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
    let password = req.query.pass
    var foundApp = false

    if (requirePassword === true){

        if (password === accessPass){

            applications['apps'].forEach(obj => {
                if (obj['name'] === appname) {
                    var exec = require('child_process').exec;
                    exec(obj['path']);
                    foundApp = true
                }
            });
            
            if (foundApp) {
                res.status(200).send(JSON.stringify({status:"ok"}))
                logConsole('Remote app executed: ' + appname)
            }else{
                res.status(401).send(JSON.stringify({status:"Unknown command or app."}))
                logConsole('Remote app stopped: Unknown command or app.')
            }

        }else{
            res.status(401).send(JSON.stringify({status:"Unauthorized."}))
            logConsole('Remote app execution stopped: wrong password')
        }

    }else{

        applications['apps'].forEach(obj => {
            if (obj['name'] === appname) {
                var exec = require('child_process').exec;
                exec(obj['path']);
                foundApp = true
            }
        });
        
        if (foundApp) {
            res.status(200).send(JSON.stringify({status:"ok"}))
            logConsole('Remote app executed: ' + appname)
        }else{
            res.status(401).send(JSON.stringify({status:"Unknown command or app."}))
            logConsole('Remote app stopped: Unknown command or app.')
        }

    }

});

app.get('/api/execCommand', async (req,res) => {
    let appname = req.query.command
    let password = req.query.pass
    var foundApp = false

    if (requirePassword === true){

        if(password === accessPass){

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

        }else{
            res.status(401).send(JSON.stringify({status:"Unauthorized."}))
            logConsole('Remote command execution stopped: wrong password')
        }

    }else{

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

    }

})

app.get('/api/stopServer', async (req,res) =>{
    let pass = req.query.pass

    if (pass === accessPass){
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