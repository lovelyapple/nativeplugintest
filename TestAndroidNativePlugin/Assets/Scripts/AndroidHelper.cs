using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class AndroidHelper : MonoBehaviour
{
    /// <summary>
    /// プラグイン側の計算クラスのインスタンス
    /// </summary>
    private AndroidJavaObject _calculator;

    /// <summary>
    /// プラグインのパッケージ名
    /// </summary>
    private const string PLUGIN_PACKAGE_NAME = "com.example.screenhelper";

    /// <summary>
    /// Javaの計算クラス名
    /// </summary>
    private const string JAVA_CLASS_NAME = "NativeCalculator";  // 要変更
    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        // インスタンス生成
        _calculator = new AndroidJavaObject("com.example.screenhelper.NativeCalculator");

        Debug.Log("_calculator " + _calculator != null);
    }
    /// <summary>
    /// OnDestroy
    /// </summary>
    private void OnDestroy()
    {
        // 解放
        _calculator?.Dispose();
        _calculator = null;
    }



    private const string ADD_METHOD = "Add";
    private const string SUBTRACT_METHOD = "Subtract";
    public void add(int num)
    {
        var result = _calculator.Call<float>(ADD_METHOD, num);  // 計算結果

        Debug.Log("result " + result);
    }
    public void subtract(int num)
    {
        var result = _calculator.Call<float>(SUBTRACT_METHOD, num);  // 計算結果
        Debug.Log("result " + result);
    }
}

[CustomEditor(typeof(AndroidHelper))]
public class AndroidHelperEditor : Editor
{
    int numberToDo;
    public override void OnInspectorGUI()
    {
        AndroidHelper helper = target as AndroidHelper;
        numberToDo = EditorGUILayout.IntField("number", +numberToDo);

        if (GUILayout.Button("add"))
        {
            helper.add(numberToDo);
        }

        if (GUILayout.Button("sub"))
        {
            helper.subtract(numberToDo);
        }
    }
}
