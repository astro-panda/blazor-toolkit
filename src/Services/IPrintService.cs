using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace AstroPanda.Blazor.Toolkit.Services;

public interface IPrintService
{
    Task Print(string targetElementId);
}

