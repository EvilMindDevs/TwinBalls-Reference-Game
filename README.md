# Unity Mobile Reference Game with Huawei Mobile Services Plugin Remote Configuration 

![image](https://user-images.githubusercontent.com/6827857/127866271-d0d1ce19-4a8c-4b58-b7f3-85e897faa776.png)

TwinBalls project is a basic hypercasual game for Unity mobile platform with Huawei Mobile Services Plugin Remote Configuration integration.

Purpose: Catch yellow balls, avoid red balls.

**Remote Configuration Features:**

You can update your game parameters without sending an application update to AppGallery. 

Such as; changing the speed of turning balls, spawn timers for balls, yellow or red ball spawn chances and score value.

These are the default values in the project.

![image](https://user-images.githubusercontent.com/6827857/127866784-0bc99c70-c358-4511-a06b-82288bf1d29c.png)

These are the values on my AppGallery Connect.

![Untitled](https://user-images.githubusercontent.com/6827857/127869760-4005700b-c7c4-455d-97ff-5cb4c23996d3.png)


## Requirements
Android SDK min 21
Net 4.x

## Important
This plugin supports:
* Unity version 2019, 2020 - Developed in master Branch
* Unity version 2018 - Developed in 2.0-2018 Branch

**Make sure to download the corresponding unity package for the Unity version you are using from the release section**

## Troubleshooting 1
Please check our [wiki page](https://github.com/EvilMindDevs/hms-unity-plugin/wiki/Troubleshooting)

## Status
This is an ongoing project, currently WIP. Feel free to contact us if you'd like to collaborate and use Github issues for any problems you might encounter. We'd try to answer in no more than a working day.

## Connect your game Huawei Mobile Services in 5 easy steps

1. Register your app at Huawei Developer
2. Import the Plugin to your Unity project
3. Connect your game with the HMS Kit Managers

### 1 - Register your app at Huawei Developer

#### 1.1-  Register at [Huawei Developer](https://developer.huawei.com/consumer/en/)

#### 1.2 - Create an app in AppGallery Connect.
During this step, you will create an app in AppGallery Connect (AGC) of HUAWEI Developer. When creating the app, you will need to enter the app name, app category, default language, and signing certificate fingerprint. After the app has been created, you will be able to obtain the basic configurations for the app, for example, the app ID and the CPID.

1. Sign in to Huawei Developer and click **Console**.
2. Click the HUAWEI AppGallery card and access AppGallery Connect.
3. On the **AppGallery Connect** page, click **My apps**.
4. On the displayed **My apps** page, click **New**.
5. Enter the App name, select App category (Game), and select Default language as needed.
6. Upon successful app creation, the App information page will automatically display. There you can find the App ID and CPID that are assigned by the system to your app.

#### 1.3 Add Package Name
Set the package name of the created application on the AGC.

1. Open the previously created application in AGC application management and select the **Develop TAB** to pop up an entry to manually enter the package name and select **manually enter the package name**.
2. Fill in the application package name in the input box and click save.

> Your package name should end in .huawei in order to release in App Gallery

#### Generate a keystore.

Create a keystore using Unity or Android Tools. make sure your Unity project uses this keystore under the **Build Settings>PlayerSettings>Publishing settings**


#### Generate a signing certificate fingerprint.

During this step, you will need to export the SHA-256 fingerprint by using keytool provided by the JDK and signature file.

1. Open the command window or terminal and access the bin directory where the JDK is installed.
2. Run the keytool command in the bin directory to view the signature file and run the command.

    ``keytool -list -v -keystore D:\Android\WorkSpcae\HmsDemo\app\HmsDemo.jks``
3. Enter the password of the signature file keystore in the information area. The password is the password used to generate the signature file.
4. Obtain the SHA-256 fingerprint from the result. Save for next step.


#### Add fingerprint certificate to AppGallery Connect
During this step, you will configure the generated SHA-256 fingerprint in AppGallery Connect.

1. In AppGallery Connect, click the app that you have created and go to **Develop> Overview**
2. Go to the App information section and enter the SHA-256 fingerprint that you generated earlier.
3. Click √ to save the fingerprint.

____

### 2 - Import the plugin to your Unity Project

To import the plugin:

1. Download the [.unitypackage](https://github.com/EvilMindDevs/hms-unity-plugin/releases)
2. Open your game in Unity
3. Choose Assets> Import Package> Custom
![Import Package](http://evil-mind.com/huawei/images/importCustomPackage.png "Import package")
4. In the file explorer select the downloaded HMS Unity plugin. The Import Unity Package dialog box will appear, with all the items in the package pre-checked, ready to install.
![image](https://user-images.githubusercontent.com/6827857/113576269-e8e2ca00-9627-11eb-9948-e905be1078a4.png)
5. Select Import and Unity will deploy the Unity plugin into your Assets Folder
____

### 3 - Update your agconnect-services.json file.

In order for the plugin to work, some kits are in need of agconnect-json file. Please download your latest config file from AGC and import into Assets/StreamingAssets folder.
![image](https://user-images.githubusercontent.com/6827857/113585485-f488bd80-9634-11eb-8b1e-6d0b5e06ecf0.png)
____

### 4 - Connect your game with any HMS Kit

In order for the plugin to work, you need to select the needed kits Huawei > Kit Settings.

In this Remote Configuration reference game , I selected the Remote Config.

![image](https://user-images.githubusercontent.com/6827857/127867748-75c61128-919d-408a-8d22-8c2c4bf2c474.png)

Remote Config is dependent on Analytics Kit. But don't worry, plugin will automatically select it for you.
It will automaticaly create the GameObject for you and it has DontDestroyOnLoad implemented so you don't need to worry about reference being lost.

Now you need your game to call the Remote Config Manager from your game. See below for further instructions.
    

## Remote Configuration
There is a custom editor in Huawei > Kit Settings > Ads tab.

![image](https://user-images.githubusercontent.com/6827857/127867698-68a810f0-4a27-4297-a1fc-ebce58943fc8.png)

You can add and use default values if user does not have an active internet connection to get parameters from AppGallery.
Insert your key name and value to create these default values.

If you check "Apply Default Values" checkbox, it will automatically apply these values.
If you want to turn on developer mode, simply checking the "Developer Mode" checkbox will enable that for you.

Then you can call certain functions such as
```csharp
    HMSRemoteConfigManager.Instance.GetValueAsFloat(floatKey);
    HMSRemoteConfigManager.Instance.GetValueAsDouble(doubleKey);
    HMSRemoteConfigManager.Instance.GetMergedAll(); // Returns all values obtained after the combination of the default values and values in Remote Configuration.
    
    HMSRemoteConfigManager.Instance.Fetch(); // Fetches latest parameter values from Remote Configuration at a customized interval. If the method is called within an interval, cached data is returned.
```
This reference game project's GameManager script can be observed as an example for remote configuration integration.

## Troubleshooting 2
1.If you received package name error , please check your package name on File->Build Settings -> Player Settings -> Other Settings -> Identification

![image](https://user-images.githubusercontent.com/67346749/125590558-e0548c36-b4e9-4510-85bb-5098c7fd9cc9.PNG)

2.If you received min sdk error , 

![image](https://user-images.githubusercontent.com/67346749/125592730-940912c8-f9b4-4f8b-8fe4-b13532342613.PNG)

please set your API level as implied in the **Requirements** section

![image](https://user-images.githubusercontent.com/67346749/125591510-fc1bbd04-b344-4924-83e9-52342a39325e.PNG)

