package com.example.caravanandroidhelper;

public class NativeCalculator {
    /**
     * 前回の計算結果
     */
    private float _lastResult = 0;

    /**
     * コンストラクタ
     */
    public NativeCalculator()
    {
        _lastResult = 0;
    }
    /**
     * 足す
     * @param num 足す値
     * @return 計算結果
     */
    public float Add(int num)
    {
        _lastResult += num;
        return _lastResult;
    }
    /**
     * 引く
     * @param num 引く値
     * @return 計算結果
     */
    public float Subtract(int num)
    {
        _lastResult -= num;
        return _lastResult;
    }
}
