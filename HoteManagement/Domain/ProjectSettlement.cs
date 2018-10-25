using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Domain
{
    public class ProjectSettlement : BaseEntity
    {
        public int id { get; set; }

        #region 工程基本信息
        /// <summary>
        /// 工程名称
        /// </summary>
        public string projectname { get; set; }
        /// <summary>
        /// 工程类型
        /// </summary>

        public string projecttype { get; set; }

        /// <summary>
        /// 工程地址
        /// </summary>

        public string projectaddress { get; set; }

        /// <summary>
        /// 规模（m2或m）
        /// </summary>
        public string projectsope { get; set; }

        /// <summary>
        /// 工程特征
        /// </summary>
        public string projectfeature { get; set; }

        /// <summary>
        /// 经办单位类型
        /// </summary>
        public string unittype { get; set; }

        /// <summary>
        /// 结算审核受理时间
        /// </summary>
        public DateTime auditstarttime { get; set; }

        /// <summary>
        /// 结算审定时间
        /// </summary>
        public DateTime auditendtime { get; set; }

        /// <summary>
        /// 审核超期原因
        /// </summary>
        public string timeoutreasion { get; set; }

        /// <summary>
        /// 中标价（万元）
        /// </summary>
        public string zprice { get; set; }

        /// <summary>
        /// 合同价（万元）
        /// </summary>
        public string cprice { get; set; }

        /// <summary>
        /// 送审价（万元）
        /// </summary>
        public string sprice { get; set; }

        /// <summary>
        /// 审定价（万元）
        /// </summary>
        public string sdprice { get; set; }

        #endregion

        #region 建设单位信息

        /// <summary>
        /// 单位名称
        /// </summary>
        public string unitname { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        public string orgcode { get; set; }

        /// <summary>
        /// 单位地址
        /// </summary>
        public string unitaddress { get; set; }

        /// <summary>
        /// 单位邮编
        /// </summary>
        public string unitzip { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string contact { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string mobile { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string idcard { get; set; }

        /// <summary>
        /// 单位号码
        /// </summary>
        public string unitphone { get; set; }
        #endregion


        #region 造价咨询单位信息
        /// <summary>
        /// 单位名称
        /// </summary>
        public string unitname2 { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        public string orgname2 { get; set; }

        /// <summary>
        /// 资质等级
        /// </summary>
        public string unitlevel { get; set; }

        /// <summary>
        /// 单位地址
        /// </summary>
        public string unitaddress2 { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string contact2 { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string mobile2 { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string idcard2 { get; set; }

        /// <summary>
        /// 单位号码
        /// </summary>
        public string unitphone2 { get; set; }

        /// <summary>
        /// 执照资格
        /// </summary>
        public string qualification { get; set; }

        /// <summary>
        /// 证书编号
        /// </summary>
        public string certificate { get; set; }

        #endregion

        #region 施工单位信息

        /// <summary>
        /// 单位名称
        /// </summary>
        public string unitname3 { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        public string orgcode3 { get; set; }

        /// <summary>
        /// 单位地址
        /// </summary>
        public string unitaddress3 { get; set; }

        /// <summary>
        /// 单位邮编
        /// </summary>
        public string unitzip3 { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string contact3 { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string mobile3 { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string idcard3 { get; set; }

        /// <summary>
        /// 单位号码
        /// </summary>
        public string unitphone3 { get; set; }

        /// <summary>
        /// 执照资格
        /// </summary>
        public string qualification2 { get; set; }

        /// <summary>
        /// 证书编号
        /// </summary>
        public string certificate2 { get; set; }

        #endregion

        #region 单位工程
        /// <summary>
        /// 单位工程名称
        /// </summary>
        public string unitprojectname { get; set; }

        //专业类别
        public string major { get; set; }

        /// <summary>
        /// 结算编制人
        /// </summary>
        public string suser { get; set; }

        /// <summary>
        /// 结算审核人
        /// </summary>
        public string sauser { get; set; }

        #endregion

        public int approvalstatues { get; set; }

        public DateTime createtime { get; set; }

        public DateTime updatetime { get; set; }

        public int createid { get; set; }

        public string reasion { get; set; }

        /// <summary>
        /// 苏州市吴江区建设工程竣工结算备案申请表
        /// </summary>
        public string applyfile { get; set; }

        /// <summary>
        /// 苏州市吴江区建设工程竣工结算备案表
        /// </summary>
        public string recordfile { get; set; }


        /// <summary>
        /// 工程造价咨询报告书
        /// </summary>
        public string reportfile { get; set; }


        /// <summary>
        /// 工程结算审定单
        /// </summary>
        public string pricefile { get; set; }


        /// <summary>
        /// 其他
        /// </summary>
        public string otherfile { get; set; }
    }
}
