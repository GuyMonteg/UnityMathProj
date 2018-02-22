using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class TestButtonsUI : UITest {

    MockNetworkClient mockNetworkClient;

    [SetUp]
    public void Init()
    {
        mockNetworkClient = new MockNetworkClient();
        // Replace the real networkClient with mock object, it will be injected later into FirstScreen component
        DependencyInjector.ReplaceComponent<NetworkClient>(mockNetworkClient);
    }

    [UnityTest] //check Info buttom
    public IEnumerator TryInfoButton()
    {
        yield return null;
        yield return LoadScene("MainMenu");
        var pause = new WaitForSeconds(1f);
        yield return WaitFor(new ObjectAppeared("Canvas"));
        yield return null;
        var settingButton = GameObject.Find("SettingButton");
        yield return Press("SettingButton");
        yield return pause;
        yield return null;
        var infoButton = GameObject.Find("InfoButton");
        //yield return Press("InfoButton");
        yield return pause;
        yield return null;
        var actualResult = infoButton.GetComponent<Image>().sprite.name;
        Assert.AreEqual(actualResult, "info");
        yield return null;
    }

    [UnityTest] 
    public IEnumerator CheckMixButton()
    {
        yield return null;
        yield return LoadScene("MainMenu");
        var pause = new WaitForSeconds(1f);
        yield return WaitFor(new ObjectAppeared("Canvas"));
        yield return null;
        var playButton = GameObject.Find("PlayButton");
        yield return Press("PlayButton");
        yield return pause;
        yield return null;
        var mixButtonPress = GameObject.Find("MixMode");
        yield return pause;
        yield return null;
        SceneManager.LoadScene("GamePlay");
        yield return null;
    }

    [UnityTest]
    public IEnumerator CheckBackButton()
    {
        yield return null;
        yield return LoadScene("MainMenu");
        var pause = new WaitForSeconds(2f);
        yield return WaitFor(new ObjectAppeared("Canvas"));
        yield return null;
        var playButton = GameObject.Find("PlayButton");
        yield return Press("PlayButton");
        yield return pause;
        yield return null;
        var mixButtonPress = GameObject.Find("BackButton");
        yield return pause;
        yield return null;
        SceneManager.LoadScene("MainMenu");
        yield return null;
    }

}
