# Scanner SDK for Web
@ Access Scanner from Web Browsers By Reliable Browser-Based Document Scanning SDK @

The Scanner SDK for Web is a powerful tool specifically crafted for web document management applications. By simply incorporating a few lines of JavaScript code, you can effortlessly establish connections with scanner hardware through web applications. Seamlessly scan documents, edit images, and securely save them to file systems or databases on Windows with utmost convenience and efficiency.

## Features

- Seamlessly access scanners from web browsers.
- Efficiently scan documents and edit images.
- Save scanned documents to file systems or databases.
- Interacting with imaging devices like scanners and cameras.
- Support all image scanners and document scanners that have drivers following the TWAIN standard.


## Dependencies

This project utilizes the `TwainDotNet.dll` library for connecting to scanners. You can find the source code and make modifications or compile it by visiting the [NTwain-SourceCode](https://github.com/rhazizi/twaindotnet) repository.


## Usage in Angular

To integrate the Scanner SDK for Web into an Angular application, follow these steps:

1. Create the `ScannedServcieResponse` model by adding the following code snippet to your project:
```typescript
export class ScannedServcieResponse {
  IsSuccess: boolean;
  Message: string;
  result: any[];
}
```

2. Call the scanner service and deserialize the JSON response into the ScannedServcieResponse model.
Here's an example of how to accomplish this:

```typescript
imageScanClick(): void {
    this.isLoading = true;
    this.notif.info('Connecting to the scanner...');
    $.ajax({
      url: "http://localhost:6565",
      data: { mode: 'SCAN' },
      type: 'POST',
      complete: function () {
      },
      success: (data) => {
        const servcieResult = <ScannedServcieResponse>JSON.parse(data);
        if (servcieResult.IsSuccess) {
          for (let index = 0; index < servcieResult.result.length; index++) {
            const element = servcieResult.result[index];
            });
          }
        }
        this.notif.clear();
        this.isLoading = false;
      },
      error: (xhr, textStatus, errorThrown) => {
        console.error('Scanner Service not found!');
        this.notif.error('Scanner service not fount!');
        this.isLoading = false;
      }
    });
  }
  ```
Please note that you should replace the endpoint URL (http://localhost:6565) with the actual URL of your scanner service.

## Contributions
Contributions to this project are welcome. If you encounter any issues or have suggestions for improvements, please feel free to open an issue or submit a pull request.

## License
This project is licensed under the [MIT License](https://github.com/rhazizi/scanner-sdk-for-web/blob/main/LICENSE).

