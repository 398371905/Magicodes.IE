﻿// ======================================================================
// 
//           filename : ImportStudentDto.cs
//           description :
// 
//           created by 雪雁 at  2019-11-05 20:02
//           文档官网：https://docs.xin-lai.com
//           公众号教程：麦扣聊技术
//           QQ群：85318032（编程交流）
//           Blog：http://www.cnblogs.com/codelove/
// 
// ======================================================================

using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Magicodes.ExporterAndImporter.Core.Filters;
using Magicodes.ExporterAndImporter.Core.Models;

namespace Magicodes.ExporterAndImporter.Tests.Models.Import
{

    /// <summary>
    /// 导入列头筛选器测试
    /// 1）测试修改列头
    /// 2）测试修改值映射
    /// </summary>
    public class ImportStudentDtoHeaderFilterTest : IImportHeaderFilter
    {
        public List<ImporterHeaderInfo> Filter(List<ImporterHeaderInfo> importerHeaderInfos)
        {
            foreach (var item in importerHeaderInfos)
            {
                if (item.PropertyName == "Gender")
                {
                    item.MappingValues = new Dictionary<string, dynamic>()
                    {
                        {"男0",0 },
                        {"女1",1 }
                    };
                }
            }
            return importerHeaderInfos;
        }
    }

    /// <summary>
    /// 导入学生数据Dto
    /// IsLabelingError：是否标注数据错误
    /// </summary>
    [ExcelImporter(IsLabelingError = true, IsDisableAllFilter = false,
        ImportHeaderFilter = typeof(ImportStudentDtoHeaderFilterTest))]
    public class ImportStudentDto
    {
        /// <summary>
        ///     序号
        /// </summary>
        [ImporterHeader(Name = "序号")]
        public long SerialNumber { get; set; }

        /// <summary>
        ///     学籍号
        /// </summary>
        [ImporterHeader(Name = "学籍号", IsAllowRepeat = false)]
        [MaxLength(30, ErrorMessage = "学籍号字数超出最大限制,请修改!")]
        public string StudentCode { get; set; }

        /// <summary>
        ///     姓名
        /// </summary>
        [ImporterHeader(Name = "姓名")]
        [Required(ErrorMessage = "学生姓名不能为空")]
        [MaxLength(50, ErrorMessage = "名称字数超出最大限制,请修改!")]
        public string Name { get; set; }

        /// <summary>
        ///     身份证号码
        /// </summary>
        [ImporterHeader(Name = "身份证号", IsAllowRepeat = false)]
        [Required(ErrorMessage = "身份证号不能为空")]
        [MaxLength(18, ErrorMessage = "身份证字数超出最大限制,请修改!")]
        public string IdCard { get; set; }

        /// <summary>
        ///     性别
        /// </summary>
        [ImporterHeader(Name = "性别")]
        [Required(ErrorMessage = "性别不能为空")]
        [ValueMapping("男", 0)]
        [ValueMapping("女", 1)]
        public Genders Gender { get; set; }

        /// <summary>
        ///     家庭地址
        /// </summary>
        [ImporterHeader(Name = "家庭住址")]
        [Required(ErrorMessage = "家庭地址不能为空")]
        [MaxLength(200, ErrorMessage = "家庭地址字数超出最大限制,请修改!")]
        public string Address { get; set; }

        /// <summary>
        ///     家长姓名
        /// </summary>
        [ImporterHeader(Name = "家长姓名")]
        [Required(ErrorMessage = "家长姓名不能为空")]
        [MaxLength(50, ErrorMessage = "家长姓名数超出最大限制,请修改!")]
        public string Guardian { get; set; }

        /// <summary>
        ///     家长联系电话
        /// </summary>
        [ImporterHeader(Name = "家长联系电话")]
        [MaxLength(20, ErrorMessage = "家长联系电话字数超出最大限制,请修改!")]
        public string GuardianPhone { get; set; }

        /// <summary>
        ///     学号
        /// </summary>
        [ImporterHeader(Name = "学号")]
        [MaxLength(30, ErrorMessage = "学号字数超出最大限制,请修改!")]
        public string StudentNub { get; set; }

        /// <summary>
        ///     宿舍号
        /// </summary>
        [ImporterHeader(Name = "宿舍号")]
        [MaxLength(20, ErrorMessage = "宿舍号字数超出最大限制,请修改!")]
        public string DormitoryNo { get; set; }

        /// <summary>
        ///     QQ
        /// </summary>
        [ImporterHeader(Name = "QQ号")]
        [MaxLength(30, ErrorMessage = "QQ号字数超出最大限制,请修改!")]
        public string QQ { get; set; }

        /// <summary>
        ///     民族
        /// </summary>
        [ImporterHeader(Name = "民族")]
        [MaxLength(2, ErrorMessage = "民族字数超出最大限制,请修改!")]
        public string Nation { get; set; }

        /// <summary>
        ///     户口性质
        /// </summary>
        [ImporterHeader(Name = "户口性质")]
        [MaxLength(10, ErrorMessage = "户口性质字数超出最大限制,请修改!")]
        public string HouseholdType { get; set; }

        /// <summary>
        ///     联系电话
        /// </summary>
        [ImporterHeader(Name = "学生联系电话")]
        [MaxLength(20, ErrorMessage = "手机号码字数超出最大限制,请修改!")]
        public string Phone { get; set; }

        /// <summary>
        ///     状态
        ///     测试可为空的枚举类型
        /// </summary>
        [ImporterHeader(Name = "状态")]
        public StudentStatus? Status { get; set; }

        /// <summary>
        ///     备注
        /// </summary>
        [ImporterHeader(Name = "备注")]
        [MaxLength(200, ErrorMessage = "备注字数超出最大限制,请修改!")]
        public string Remark { get; set; }

        /// <summary>
        ///     是否住校(宿舍)
        /// </summary>
        [ImporterHeader(IsIgnore = true)]
        public bool? IsBoarding { get; set; }

        /// <summary>
        ///     所属班级id
        /// </summary>
        [ImporterHeader(IsIgnore = true)]
        public Guid ClassId { get; set; }

        /// <summary>
        ///     学校Id
        /// </summary>
        [ImporterHeader(IsIgnore = true)]
        public Guid? SchoolId { get; set; }

        /// <summary>
        ///     校区Id
        /// </summary>
        [ImporterHeader(IsIgnore = true)]
        public Guid? CampusId { get; set; }

        /// <summary>
        ///     专业Id
        /// </summary>
        [ImporterHeader(IsIgnore = true)]
        public Guid? MajorsId { get; set; }

        /// <summary>
        ///     年级Id
        /// </summary>
        [ImporterHeader(IsIgnore = true)]
        public Guid? GradeId { get; set; }
    }


    /// <summary>
    ///     性别
    /// </summary>
    public enum Genders
    {
        /// <summary>
        ///     男
        /// </summary>
        Man = 0,

        /// <summary>
        ///     女
        /// </summary>
        Female = 1
    }

    /// <summary>
    ///     学生状态 正常、流失、休学、勤工俭学、顶岗实习、毕业、参军
    /// </summary>
    public enum StudentStatus
    {
        /// <summary>
        ///     正常
        /// </summary>
        [Display(Name = "正常")] Normal = 0,

        /// <summary>
        ///     流失
        /// </summary>
        [Display(Name = "流水")]
        [Description("流水")] PupilsAway = 1,

        /// <summary>
        ///     休学
        /// </summary>
        [Display(Name = "休学")] Suspension = 2,

        /// <summary>
        ///     勤工俭学
        /// </summary>
        [Display(Name = "勤工俭学")] WorkStudy = 3,

        /// <summary>
        ///     顶岗实习
        /// </summary>
        [Display(Name = "顶岗实习")] PostPractice = 4,

        /// <summary>
        ///     毕业
        /// </summary>
        [Display(Name = "毕业")] Graduation = 5,

        /// <summary>
        ///     参军
        /// </summary>
        [Display(Name = "参军")] JoinTheArmy = 6
    }
}