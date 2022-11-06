using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Blazor.PrintableArea.Services;

public interface IPrintService
{
    Task Print(string targetElementId);
}

