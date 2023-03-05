using System.ComponentModel.DataAnnotations;

namespace WebAPI.Database.Dtos;

public class ResumeDto
{
    [Key]
    public string id { get; set; }
    public string resume_title { get; set; }
    public string resume_template { get; set; }
    public string job_title { get; set; }
    public string photo_url { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public string dob { get; set; }
    public string pd_city { get; set; }
    public string summary { get; set; }
    public string created_at { get; set; }
    public string updated_at { get; set; }
}