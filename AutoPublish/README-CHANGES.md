# AutoPublisher - تغییرات اعمال‌شده

- اضافه شدن mode جدید PublishWithDelay
- اضافه شدن checkbox برای فراخوانی API مربوط به Under Maintenance قبل از عملیات
- دریافت BaseUrl مربوط به سرویس Under Maintenance از داخل فرم
- تولید خودکار username/password پویا با الگوی DateTime.Now:MHd
- اضافه شدن Local API داخلی با HttpListener برای اتصال از ServerManagment

## Local API
- Health: GET /api/health
- Publish: POST /api/publish

نمونه payload:
```json
{
  "projectName": "MyProject",
  "projectDirectory": "D:\\Projects\\MyProject",
  "projectBinDirectory": "D:\\Projects\\MyProject\\bin\\Release\\net9.0\\publish",
  "publishTargetDirectory": "D:\\PublishTarget",
  "mode": "PublishWithDelay",
  "callUnderMaintenanceBeforePublish": true,
  "publishDelayMinutes": 10,
  "underMaintenanceBaseUrl": "https://localhost:7216/"
}
```
