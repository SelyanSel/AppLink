<a name="readme-top"></a>

<br />
<div align="center">
  <a href="https://github.com/SelyanSel/AppLink/">
    <img src="https://github.com/SelyanSel/AppLink/blob/main/.applink/server/web/assets/appLink.png" alt="Logo" width="80" height="80">
  </a>

<h3 align="center">AppLink</h3>

  <p align="center">
    Run apps on your computer with a simple request!
    <br />
    <a href="https://github.com/SelyanSel/AppLink/wiki"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/SelyanSel/AppLink/">View Demo</a>
    ·
    <a href="https://github.com/SelyanSel/AppLink//issues">Report Bug</a>
    ·
    <a href="https://github.com/SelyanSel/AppLink//issues">Request Feature</a>
  </p>
</div>

## About AppLink

AppLink is a node-js and web based application that allows to setup a local server and run apps or commands with a simple GET request.

# 💻 Getting Started

This will guide you through the initial setup of AppLink, and starting for the first time the AppLink server.

## Requirements

* Latest nodejs version. [Available here.](https://nodejs.org/fr)
* .NET Framework 4.7.2
* A brain

## 1️⃣ Server setup

* Once you unzipped into a new folder the latest release [here](https://github.com/SelyanSel/AppLink/releases), run the "change_server_settings.bat".
* Opened, you will be prompted with notepad and a bunch of text. This text is the .env of the server, if you don't know what this means, it's basically the settings of the server.
![image](https://github.com/SelyanSel/AppLink/assets/53857450/658c5cc5-4a16-46e7-8290-f394769b68b7) (should look something like that)
* We recommand not changing any of the values here (except one), although you can check the full settings meaning [here]().
* Change the `accessPassword` with a password of your choice. This prevents anyone run anything on your computer, without password. Make sure only you know that password, and remember it, you will need it later on.
* Save and close that notepad window.

## 2️⃣ First-time run

* Execute the "start_server.bat" file. You will be prompted with the AppLinkConfigurator app. This app allows you to edit AppLink settings easily.
* The page below should pop up.<br><br>
![image](https://github.com/SelyanSel/AppLink/assets/53857450/0bf7db17-ac8d-48c3-bab0-a86a0b5e498e)<br><br>
* Check the two boxes "Always start when AppLink server is offline" and "Always start AppLink silently and press "Start"

* After all of this, this page should open: <br><br>
![image](https://github.com/SelyanSel/AppLink/assets/53857450/5d2b7d95-58c4-41bd-8412-99a8561f8a66)<br>
_TIP: If you want the log window, check the "Enable Log Window" checkmark near the "Start/Restart server" button._<br>
* Click the "Start/Restart Server" button, then press the "Refresh" button near the "INACTIVE" text. A message box saying "Modules needs to be installed..." will pop up. Press OK and wait until the CMD window is closed.
* When the CMD window is closed, press again the "Start/Restart Server" button. If everything went correctly, the server should start!
* You can make AppLink work in the background by closing this window:<br><br>
![image](https://github.com/SelyanSel/AppLink/assets/53857450/0bf7db17-ac8d-48c3-bab0-a86a0b5e498e)<br><br>
* To reopen it, open your Icon Tray and click on the AppLink logo (this one below)<br><br>
![image](https://github.com/SelyanSel/AppLink/assets/53857450/44bcb81f-9fff-486e-ba9d-923722a1add7)<br><br>

## 3️⃣ Using AppLink
* To use AppLink, nothing complicated. Once the server is up and running, you should be able to check it by going to this URL: http://localhost:9989/
* The page should look like this:<br><br>
![image](https://github.com/SelyanSel/AppLink/assets/53857450/acc247f2-357f-465e-816e-c6dd77d48827)
<br><br>
* If you see this page, **congrats!** AppLink is now running. 
* AppLink has 2 built-in apps you can now start. To start File Explorer for example, open this URL: http://localhost:9989/api/openApp?name=explorer&pass=1234
* WARNING: The URL right there only works if you haven't changed the default password! If you did, just change the password at the end of the URL.
<br><br>

Congrats 🎉 AppLink is up and running on your system (if you followed everything correctly).
You can access it with others computers, phones, anything from your local IP. (search on google to know your local ip, it should look like this at the end for example: http://192.168.1.**:9989/api/openApp?name=explorer&pass=1234)

View full wiki page [here](https://github.com/SelyanSel/AppLink/wiki/Getting-Started)

## Roadmap

- [ ] Full app & command editing support in AppLinkConfigurator
- [ ] Saved logs in a file

See the [open issues](https://github.com/SelyanSel/AppLink//issues) for a full list of proposed features (and known issues).

## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

## Contact

[My website](https://f4r9.com/) - [Project Link](https://github.com/SelyanSel/AppLink/)

<p align="right">(<a href="#readme-top">back to top</a>)</p>
