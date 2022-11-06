export function print(targetElemId) {
    var targetElem = document.getElementById(targetElemId);
    var allCss = [...document.styleSheets]
        .map(styleSheet => {
            try {
                return [...styleSheet.cssRules]
                    .map(rule => rule.cssText)
                    .join('');
            } catch (e) {
                console.log('Access to stylesheet %s is denied. Ignoring...', styleSheet.href);
            }
        })
        .filter(Boolean)
        .join('\n');
    var win = window.open('', '', 'height=' + targetElem.offsetHeight + ', width=' + targetElem.offsetWidth);
    win.document.write("<style>");
    win.document.write(allCss);
    win.document.write("</style>");
    win.document.write(targetElem.parentElement.innerHTML);
    win.print();
}