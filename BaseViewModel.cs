using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

/*
 * UNIVERSAL HELPER (Works for WPF and Avalonia)
 * 1. Inherit from this class: public class MyVM : BaseViewModel
 * 2. Use SetProperty in your setters:
 * set => SetProperty(ref _myField, value);
 */
public abstract class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
    {
        if (System.Collections.Generic.EqualityComparer<T>.Default.Equals(backingStore, value))
            return false;

        backingStore = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
