export async function downloadStream(filename, stream) {
    const arrayBuffer = await stream.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const url = URL.createObjectURL(blob);
    
    download(filename, url);

    URL.revokeObjectURL(url);
}

export function downloadFile(filename, uri) {
    const anchorElement = document.createElement('a');
    anchorElement.href = uri;
    anchorElement.download = filename ?? '';
    anchorElement.click();
    anchorElement.remove();
}
