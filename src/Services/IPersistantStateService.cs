using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPanda.Blazor.Toolkit.Services;

public interface IPersistentStateService<T>
{
    /// <summary>
    /// The a class containing the properties to store
    /// </summary>
    T Properties { get; set; }

    /// <summary>
    /// Load the stored <see cref="Properties"/> from local storage.
    /// </summary>
    void LoadState();

    Task LoadStateAsync();

    /// <summary>
    /// Save the <see cref="Properties"/> into local storage.
    /// </summary>
    Task SaveState();

}