using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace exam
{
    // =========================
    // 数据中心
    // =========================
    public class DataCenter
    {
        public static List<Student> Students = new List<Student>();
        public static List<Record> Records = new List<Record>();

        public static Action<string> LogAction;

        public static void Log(string msg)
        {
            LogAction?.Invoke($"{DateTime.Now:HH:mm:ss} {msg}");
        }
    }

    // =========================
    // 业务服务（上传/下载）
    // =========================
    public class UploadDownloadService
    {
        public object GetStudents()
        {
            DataCenter.Log("设备请求：下载学生信息");

            return new
            {
                ResultSuccess = true,
                ResultCode = "0001",
                ResultMsg = "",   // ★ 必须加
                ResultData = DataCenter.Students
            };
        }

        public object UploadRecords(List<Record> list)
        {
            DataCenter.Log($"设备上传成绩：{list.Count}条");

            DataCenter.Records.AddRange(list);

            return new
            {
                ResultSuccess = true,
                ResultCode = "0001"
            };
        }

        public object QueryResult(string sid)
        {
            DataCenter.Log($"查询成绩：{sid}");

            var result = DataCenter.Records.Where(x => x.test_id == sid).ToList();

            return new
            {
                ResultSuccess = true,
                ResultCode = "0001",
                ResultData = result
            };
        }
    }

    // =========================
    // WebAPI 控制器
    // =========================
    [ApiController]
    [Route("app")]
    public class AppController : ControllerBase
    {
        private UploadDownloadService service = new UploadDownloadService();

        [HttpGet("students")]
        public IActionResult Students()
        {
            return Ok(service.GetStudents());
        }

        [HttpPost("records")]
        public IActionResult Records([FromBody] RecordRequest req)
        {
            return Ok(service.UploadRecords(req.data));
        }

        [HttpPost("sturesults")]
        public IActionResult Results([FromBody] SidRequest req)
        {
            return Ok(service.QueryResult(req.sid));
        }
    }

    // =========================
    // WebAPI 启动控制
    // =========================
    public class ApiHost
    {
        private IHost host;

        public void Start(int port = 9095)
        {
            host = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls($"http://192.168.0.7:{port}");
                    webBuilder.ConfigureServices(services =>
                    {
                        //services.AddControllers();
                        services.AddControllers()
                            .AddJsonOptions(options =>
                            {
                                options.JsonSerializerOptions.PropertyNamingPolicy = null; // ★ 关键
                            });
                    });
                    webBuilder.Configure(app =>
                    {
                        app.UseRouting();
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                        });
                    });
                })
                .Build();

            host.Start();

            DataCenter.Log($"服务已启动：http://192.168.0.7:{port}");
        }

        public void Stop()
        {
            host?.StopAsync();
            DataCenter.Log("服务已停止");
        }
    }

    // =========================
    // 数据模型
    // =========================
    public class Student
    {
        public string test_id { get; set; }
        public string id_card_number { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string ethnic { get; set; }
        public string birth { get; set; }
        public string address { get; set; }
        public int? age { get; set; }
        public string current_class { get; set; }
        public int? current_grade { get; set; }
        public string gradename { get; set; }
        public string school { get; set; }
    }

    public class Record
    {
        public string test_id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string test_item { get; set; }
        public string data { get; set; }
        public string test_date { get; set; }
    }

    public class RecordRequest
    {
        public List<Record> data { get; set; }
    }

    public class SidRequest
    {
        public string sid { get; set; }
    }
}