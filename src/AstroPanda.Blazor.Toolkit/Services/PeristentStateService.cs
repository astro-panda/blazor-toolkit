using Blazored.LocalStorage;

namespace AstroPanda.Blazor.Toolkit

public class PersistentStateService<T> : IPersistentStateService<T> where T: new()
{
    public PersistentStateService(ILocalStorageService localStorage, ISyncLocalStorageService localStorageSync)
    {
        _localStorageSync = localStorageSync;
        _localStorage = localStorage;
    }

    public PersistentStateService(ILocalStorageService localStorage, ISyncLocalStorageService localStorageSync, string localStorageKey)
    {
        _localStorageSync = localStorageSync;
        _localStorage = localStorage;
        _localStorageKey = localStorageKey;
    }

    private ILocalStorageService _localStorage;
    private ISyncLocalStorageService _localStorageSync;

    private string _localStorageKey = "PersistentState";

    public T Properties { get; set; } = new();

    public async Task LoadStateAsync()
    {
        Properties = await _localStorage.GetItemAsync<T>(_localStorageKey);
        if (Properties is null)
        {
            Properties = new ();
            await _localStorage.SetItemAsync(_localStorageKey, Properties);
        }
    }

    public void LoadState()
    {
        Properties = _localStorageSync.GetItem<T>(_localStorageKey);
        if (Properties is null)
        {
            Properties = new();
            _localStorageSync.SetItem(_localStorageKey, Properties);
        }
    }

    public async Task SaveState()
    {
        await _localStorage.SetItemAsync(_localStorageKey, Properties);
    }
}