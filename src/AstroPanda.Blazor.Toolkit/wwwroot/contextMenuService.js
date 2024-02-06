document.addEventListener("mousedown", (event) => {
    const contextMenuIds = [];
    const elementsUnderMouse = document.elementsFromPoint(event.clientX, event.clientY);
    console.trace("*** The custom click listener was called");

    elementsUnderMouse.forEach(function (x) {
        if (!!x.getAttribute('context-menu-guid')) {
            console.trace("*** Clicked on a context menu");
            contextMenuIds.push(x.getAttribute('context-menu-guid'));
        }
    });

    if (contextMenuIds.length !== 0) {
        console.trace("*** Attempting to call the CloseActiveContextMenu method from js");
        DotNet.invokeMethodAsync('AstroPanda.Blazor.Toolkit', 'CloseActiveContextMenu');
    }
});