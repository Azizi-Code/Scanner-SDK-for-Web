# Use Scanner In WebApplications
@ Access Scanner from Web Browsers By Reliable Browser-Based Document Scanning SDK @

This SDK designed for web document management applications. With just a few lines of JavaScript code, you can develop robust web applications to scan documents, edit images and save them to file systems on Windows.



in angular you can use same as below code :

1- first make ScannedServcieResponse model
```
export class ScannedServcieResponse {
  IsSuccess: boolean;
  Message: string;
  result: any[];
}
```
2- Call scanner service and deserializing json to ScannedServcieResponse model.
```
imageScanClick(): void {
    this.isLoading = true;
    this.notif.info('در حال ارتباط با اسکنر...');
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
        this.notif.error('سرویس اسکنر پیدا نشد!');
        this.isLoading = false;
      }
    });
  }
  ```
