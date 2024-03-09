export class ClipboardService {
    static async copyRemoteImgToClipboard(imgUrl) {
        try {
            const data = await fetch(imgUrl);
            const blob = await data.blob();
            await navigator.clipboard.write([
                new ClipboardItem({
                    [blob.type]: blob,
                }),
            ]);
            console.log('Image copied.');
        } catch (err) {
            console.error(err.name, err.message);
        }
    }

    static async copySvgToClipboard(svgElementId) {
        const svg = document.getElementById(svgElementId);
        const { height, width } = svg.getBoundingClientRect();

        const svgString = new XMLSerializer().serializeToString(svg);
        const svgBase64 = btoa(svgString);

        const image = new Image();
        image.src = `data:image/svg+xml;base64,${svgBase64}`;

        image.onload = () => {

            const canvas = document.createElement('canvas');
            canvas.width = width;
            canvas.height = height;
            const context = canvas.getContext('2d');
            context.drawImage(image, 0, 0);

            try {
                canvas.toBlob(async blob => {
                    if ('write' in navigator.clipboard) {
                        await navigator.clipboard.write([
                            new ClipboardItem({
                                [blob.type]: blob
                            }),
                        ]);
                        console.log("Image Copied")
                        // Image copied as image.
                    } else {
                        // const text = await responsePromise.then(response => response.text());
                        //await navigator.clipboard.writeText(text);
                        // Image copied as source code.
                    }
                }, 'image/png', 1);
            } catch (err) {
                console.error(err.name, err.message);
            }
        };
    }

    static toPNGBlob = async (img, height, width) => {
        const canvas = new OffscreenCanvas(height, width);
        const ctx = canvas.getContext('2d');
        // This removes transparency. Remove at will.
        ctx.fillStyle = '#fff';
        ctx.fillRect(0, 0, canvas.width, canvas.height);
        ctx.drawImage(img, 0, 0);
        return await canvas.convertToBlob();
    };
}

window.ClipboardService = ClipboardService;