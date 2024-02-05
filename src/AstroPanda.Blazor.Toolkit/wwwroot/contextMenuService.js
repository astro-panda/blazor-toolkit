document.addEventListener("mousedown", (event) => {
    const contextMenuIds = [];
    const elementsUnderMouse = document.elementsFromPoint(event.clientX, event.clientY);

    elementsUnderMouse.forEach(function (x) {
        if (!!x.getAttribute('context-menu-guid')) {
            contextMenuIds.push(x.getAttribute('context-menu-guid'));
        }
    });

    if (contextMenuIds.length !== 0) {
        console.log("*** Attempting to call the CloseActiveContextMenu method from js")
        DotNet.invokeMethodAsync('AstroPanda.Blazor.Toolkit', 'CloseActiveContextMenu');
    }
});