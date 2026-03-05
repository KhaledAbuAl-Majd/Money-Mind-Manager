using System;
using System.ComponentModel;

namespace MoneyMindManager.Core.Enums
{
    [Flags]
    public enum enPermissions
    {
        [Description("(جميع الصلاحيات (أدمن")]
        Admin = -1,

        [Description("قائمة الأشخاص")]
        PeopleList = 1,//done

        [Description("إضافة/تعديل شخص")]
        AddUpdatePerson = 2,//done

        [Description("حذف شخص")]
        DeletePerson = 4,//done

        [Description("قائمة المستخدمين")]
        UsersList = 8,//done

        [Description("قائمة مستندات الواردات")]
        IncomeVouchersList = 16,//done

        [Description("قائمة مستندات المصروفات")]
        ExpenseVouchersList = 32,//done

        [Description("قائمة مستندات مرتجعات المصروفات")]
        ExpenseReturnVouchersList = 64,//done

        [Description("غلق/فتح المستندات (واردات - مصروفات - مرتجعات مصروفات)")]
        ChangeIETVoucherLocking = 128,//done

        [Description("إضافة/تعديل مستندات - معاملات (واردات - مصروفات - مرتجعات مصروفات)")]
        AddUpdateIETVoucher_Transactions = 256,//done

        [Description("حذف مستندات - معاملات (واردات - مصروفات - مرتجعات مصروفات)")]
        DeleteIETVoucher_Transactions = 512,//done

        [Description("قائمة سندات الديون")]
        DebtsList = 1024,//done

        [Description("غلق/فتح سندات الديون")]
        ChangeDebtsLocking = 2048,//done

        [Description("إضافة/تعديل (سندات - معاملات سداد) الديون")]
        AddUpdateDebt_Payments = 4096,//done

        [Description("حذف (سندات - معاملات سداد) الديون")]
        DeleteDebt_Payments = 8192,//done

        [Description("قائمة الفئات")]//done
        CategoriesList = 16384,

        [Description("إضافة/تعديل فئة")]
        AddUpdateCategory = 32768,//done

        [Description("حذف فئة")]
        DeleteCategory = 65536,//done

        [Description("تغيير فعالية فئة")]//done
        ChangeCategoryActivation = 131072,

        [Description("تخطي الميزانية الشهرية لفئات المصروفات")]
        ExceedsCategoryBudget = 262144,//done

        [Description("قائمة المعاملات")]
        MainTransactionsList = 524288,//done

        [Description("شاشة اللمحة العامة")]
        OverView = 1048576,//done

        [Description("رؤية رصيد الحساب")]
        AccountBalance = 2097152 //done
    }

}
