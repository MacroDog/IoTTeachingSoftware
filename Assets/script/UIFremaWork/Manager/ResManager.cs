using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AssetInfo
{
    private UnityEngine.Object _object;
    public Type AssetType { get; set; }
    public string Path { get; set; }
    public int RefCount { get; set; }
    public bool IsLoaded
    {
        get
        {
            return null != _object;
        }
    }

    public IEnumerator GetCoroutineObject(Action<UnityEngine.Object> _loaded)
    {
        while (true)
        {
            yield return null;
            if (_object == null)
            {
                _ResourcesLoad();
                yield return null;
            }
            else
            {
                if (_loaded!=null)
                    _loaded(_object);   
            }
            yield break;
        }

    }
    private void _ResourcesLoad()
    {
        try
        {
            _object = Resources.Load(Path);
            if (_object == null)
            {
                Debug.Log("Resoures load fialure! Path+" + Path);
            }
        }
        catch (Exception e)
        {

            Debug.Log(e.ToString());
        }
    }
    public UnityEngine.Object AssetObject
    {
        get
        {
            if (null == _object)
            {
                _ResourcesLoad();
            }
            return _object;

        }
    }
    public IEnumerator GetAsyncObject(Action<UnityEngine.Object> _load)
    {
        return GetAsyncObject(_load, null);

    }
    public IEnumerator GetAsyncObject(Action<UnityEngine.Object> _load, Action<float> _progress)
    {
        //have object 
        if (_object != null)
        {
            _load(_object);
            yield break;
        }
        //object null. not load Resouurces
        ResourceRequest _resourceReqest = Resources.LoadAsync(Path);
        while (_resourceReqest.progress < 0.9)
        {
            if (null != _progress)
                _progress(_resourceReqest.progress);
            yield return null;

        }
        while (!_resourceReqest.isDone)
        {
            if (_progress != null)
            {
                _progress(_resourceReqest.progress);
            }
            yield return null;
        }
        _object = _resourceReqest.asset;
        if (_load != null)
        {
            _load(_object);
        }
        yield return _resourceReqest;
    }
}

public class ResManager : Singleton<ResManager>
{

    private Dictionary<string, AssetInfo> dicAssetInfo = null;
    public override void Init()
    {
        dicAssetInfo = new Dictionary<string,AssetInfo>() ;
    }
    #region Load Resources&Instantiate object
    /// <summary>
    /// loads the instance.
    /// </summary>
    /// <param name="_path"></param>
    /// <returns></returns>
    public UnityEngine.Object LoadInstantance(string _path)
    {
        UnityEngine.Object _obj = Load(_path);
        return Instantiate(_obj);
    }
    public void LoadCoroutineInstaniate(string _path,Action<UnityEngine.Object> _loaded)
    {
        LoadCoroutine(_path, (_obj) => { Instantiate(_obj, _loaded); });
    }
    public void LoadAsyncInstantiate(string _path, Action<UnityEngine.Object> _loaded)
    {
        LoadAsync(_path, (_obj) => { Instantiate(_obj, _loaded); });
    }
    public void LoadAsyncInstantiate(string _Path, Action<UnityEngine.Object> _loaded, Action<float> _progress)
    {
        LoadAsync(_Path, (_obj) => { Instantiate(_obj, _loaded); }, _progress );
    }
    #endregion

    #region Load Coroutine Resources
    /// <summary>
    /// loads the coroutine.
    /// </summary>
    /// <param name="_path"></param>
    /// <param name="_load"></param>
    public void LoadCoroutine(string _path,Action<UnityEngine.Object> _load)
    {
        AssetInfo _assetInfo = GetAssetInfo(_path);
        if (_assetInfo!=null)
        {
            CoroutineController.Instance.StartCoroutine(_assetInfo.GetCoroutineObject(_load));
           
        }
    }
    #endregion

    #region Load Resources
    public UnityEngine.Object Load(string _path)
    {
        AssetInfo _assetInfo = GetAssetInfo(_path);
        if (_assetInfo!=null)
        {
            return _assetInfo.AssetObject;
        }
        return null;
    }
    #endregion

    #region Load Async Resources
    public void LoadAsync(string _path, Action<UnityEngine.Object> _load)
    {
        LoadAsync(_path, _load, null);
    }
    public void LoadAsync(string _path, Action<UnityEngine.Object> _load, Action<float> _progress)
    {
        AssetInfo _assinfo = GetAssetInfo(_path);
        if (_assinfo != null)
        {
            CoroutineController.Instance.StartCoroutine(_assinfo.GetAsyncObject(_load, _progress));
        }
    }
    #endregion
    #region Get AssetInfo& Instances object
    private AssetInfo GetAssetInfo(string _path)
    {
        return GetAssetInfo(_path, null);
    }
    private AssetInfo GetAssetInfo(string _path, Action<UnityEngine.Object> _load)
    {
        if (string.IsNullOrEmpty(_path))
        {
            Debug.LogError("Error: null _path name");
            if (_load != null)
                _load(null);
        }
        AssetInfo _assetInfo = null;
        if (!dicAssetInfo.TryGetValue(_path, out _assetInfo))
        {
            _assetInfo = new AssetInfo();
            _assetInfo.Path = _path;
            dicAssetInfo.Add(_path, _assetInfo);
        }
        _assetInfo.RefCount++;
        return _assetInfo;

    }

    private UnityEngine.Object Instantiate(UnityEngine.Object _obj)
    {
        return Instantiate(_obj, null);
    }
    private UnityEngine.Object Instantiate(UnityEngine.Object _obj, Action<UnityEngine.Object> _load)
    {
        UnityEngine.Object _retObj = null;
        if (_obj != null)
        {
            _retObj = MonoBehaviour.Instantiate(_obj);
            if (_retObj != null)
            {
                if (_load != null)
                {
                    _load(_retObj);
                    return null;
                }
                return _retObj;
            }
            else
            {
                Debug.LogError("Error:null Instantiate _retObject");
            }
        }
        else
        {
            Debug.LogError("Error:null Resources Load return _obj");
        }
        return null;
    }
    #endregion




}
