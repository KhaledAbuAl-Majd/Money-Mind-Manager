using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KhaledControlLibrary1;

namespace MoneyMindManager_Presentation.Global
{
    public static class clsUtils
    {
        /// <summary>
        /// Get validation Error Type String of KhaledGuna2TextBox.ValidatingErrorEventArgs.enValidationErrorType
        /// </summary>
        /// <param name="validationErrorType">KhaledGuna2TextBox.ValidatingErrorEventArgs.enValidationErrorType</param>
        /// <param name="kgtxtBox">KhaledGuna2TextBox object</param>
        /// <returns>Error String</returns>
        public static string GetValidationErrorTypeString(KhaledGuna2TextBox.ValidatingErrorEventArgs.enValidationErrorType validationErrorType,KhaledGuna2TextBox kgtxtBox)
        {
            string errorMessage = null;

            switch (validationErrorType)
            {
                case KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs.enValidationErrorType.General:
                    errorMessage = "برجاء إدخال قيمة مناسبة";
                    break;

                case KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs.enValidationErrorType.IsRequired:
                    errorMessage = "هذا الحقل مطلوب";
                    break;

                case KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs.enValidationErrorType.NotValidIntegerNumber:
                    errorMessage = "برجاء إدخال رقم صحيح";
                    break;

                case KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs.enValidationErrorType.NotValidFloatNumber:
                    errorMessage = "برجاء إدخل رقم عشرى مناسب";
                    break;

                case KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs.enValidationErrorType.NotValidDecimalNumber:
                    errorMessage = "برجاء إدخل رقم عشرى مناسب";
                    break;

                case KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs.enValidationErrorType.SkipNumberMinValue:
                    {
                        decimal minValue = 0;

                        switch (kgtxtBox.NumberProperties.NumberInputTypes)
                        {
                            case KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber:
                                {
                                    minValue = Convert.ToDecimal(kgtxtBox.NumberProperties.IntegerNumberProperties.MinValue);
                                    break;
                                }

                            case KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.FloatNumber:
                                {
                                    minValue = Convert.ToDecimal(kgtxtBox.NumberProperties.FloatNumberProperties.MinValue);
                                    break;
                                }

                            case KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.DecimalNumber:
                                {
                                    minValue = kgtxtBox.NumberProperties.DecimalNumberProperties.MinValue;
                                    break;
                                }

                            default:
                                minValue = 0;
                                break;
                        }

                        errorMessage = $"لقد تخطيت أقل قيمة صالحة [{minValue.ToString()}], يرجى إدخل قيمة مناسبة";
                        break;
                    }

                case KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs.enValidationErrorType.SkipNumberMaxValue:
                    {
                        decimal maxValue = 0;

                        switch (kgtxtBox.NumberProperties.NumberInputTypes)
                        {
                            case KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber:
                                {
                                    maxValue = Convert.ToDecimal(kgtxtBox.NumberProperties.IntegerNumberProperties.MaxValue);
                                    break;
                                }

                            case KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.FloatNumber:
                                {
                                    maxValue = Convert.ToDecimal(kgtxtBox.NumberProperties.FloatNumberProperties.MaxValue);
                                    break;
                                }

                            case KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.DecimalNumber:
                                {
                                    maxValue = kgtxtBox.NumberProperties.DecimalNumberProperties.MaxValue;
                                    break;
                                }

                            default:
                                maxValue = 0;
                                break;
                        }

                        errorMessage = $"لقد تخطيت أكبر قيمة صالحة [{maxValue.ToString()}], يرجى إدخل قيمة مناسبة";
                        break;
                    }

                case KhaledGuna2TextBox.ValidatingErrorEventArgs.enValidationErrorType.NotValidTextEmail:
                    errorMessage = "صيغة البريد غير صحيحة , برجاء إدخال بريد آخر مناسب";
                    break;

                case KhaledGuna2TextBox.ValidatingErrorEventArgs.enValidationErrorType.NotValidTextPhone:
                    errorMessage = "صيغة الهاتف غير صحيحة ,برجاء إدخال رقم آخر مناسب";
                    break;

                case KhaledGuna2TextBox.ValidatingErrorEventArgs.enValidationErrorType.SkipTextMinLength:
                    {

                        short minTextLength = kgtxtBox.TextProperties.MinLength;
                        errorMessage = $"طول النص أقل من القيمة المطلوبة [{minTextLength.ToString()}], برجاء إدخال قيمة صالحة";
                        break;
                    }

                default:
                    errorMessage = "برجاء إدخال قيمة مناسبة";
                    break;
            }

            return errorMessage;
        }
    }
}
