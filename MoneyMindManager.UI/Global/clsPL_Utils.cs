using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KhaledControlLibrary1;

namespace MoneyMindManager_Presentation.Global
{
    public static class clsPL_Utils
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

                case KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs.enValidationErrorType.WhiteSapceError:
                    errorMessage = "غير مسموح بالمسافات, برجاء إدخال قيمة صالحة";
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
                        bool isMinValueIncluded = false;
                        decimal minValue = 0;

                        switch (kgtxtBox.NumberProperties.NumberInputTypes)
                        {
                            case KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber:
                                {
                                    minValue = Convert.ToDecimal(kgtxtBox.NumberProperties.IntegerNumberProperties.MinValue);
                                    isMinValueIncluded = kgtxtBox.NumberProperties.IntegerNumberProperties.MinValueIncluded;
                                    break;
                                }

                            case KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.FloatNumber:
                                {
                                    minValue = Convert.ToDecimal(kgtxtBox.NumberProperties.FloatNumberProperties.MinValue);
                                    isMinValueIncluded = kgtxtBox.NumberProperties.FloatNumberProperties.MinValueIncluded;
                                    break;
                                }

                            case KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.DecimalNumber:
                                {
                                    minValue = kgtxtBox.NumberProperties.DecimalNumberProperties.MinValue;
                                    isMinValueIncluded = kgtxtBox.NumberProperties.DecimalNumberProperties.MinValueIncluded;
                                    break;
                                }

                            default:
                                minValue = 0;
                                isMinValueIncluded = false;
                                break;
                        }

                        string minString = (isMinValueIncluded) ? $"يجب أن تكون القيمة اكبر من أو يساوي [{minValue.ToString()}]" :
                            $"يجب أن تكون القيمة أكبر من [{minValue.ToString()}]";

                        errorMessage = $"لقد تخطيت أقل قيمة صالحة, {minString} , برجاء إدخل قيمة مناسبة";
                        break;
                    }

                case KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs.enValidationErrorType.SkipNumberMaxValue:
                    {
                        bool isMaxValueIncluded = false;
                        decimal maxValue = 0;


                        switch (kgtxtBox.NumberProperties.NumberInputTypes)
                        {
                            case KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber:
                                {
                                    maxValue = Convert.ToDecimal(kgtxtBox.NumberProperties.IntegerNumberProperties.MaxValue);
                                    isMaxValueIncluded = kgtxtBox.NumberProperties.IntegerNumberProperties.MaxValueIncluded;
                                    break;
                                }

                            case KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.FloatNumber:
                                {
                                    maxValue = Convert.ToDecimal(kgtxtBox.NumberProperties.FloatNumberProperties.MaxValue);
                                    isMaxValueIncluded = kgtxtBox.NumberProperties.FloatNumberProperties.MaxValueIncluded;
                                    break;
                                }

                            case KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.DecimalNumber:
                                {
                                    maxValue = kgtxtBox.NumberProperties.DecimalNumberProperties.MaxValue;
                                    isMaxValueIncluded = kgtxtBox.NumberProperties.DecimalNumberProperties.MaxValueIncluded;
                                    break;
                                }

                            default:
                                maxValue = 0;
                                break;
                        }

                        string maxString = (isMaxValueIncluded) ? $"يجب أن تكون القيمة أقل من أو يساوي [{maxValue.ToString()}]" :
                            $"يجب أن تكون القيمة أقل من [{maxValue.ToString()}]";

                        errorMessage = $"لقد تخطيت أكبر قيمة صالحة, {maxString} , برجاء إدخل قيمة مناسبة";
                        break;
                    }

                case KhaledGuna2TextBox.ValidatingErrorEventArgs.enValidationErrorType.NotValidTextEmail:
                    errorMessage = "صيغة البريد غير صحيحة , برجاء إدخال بريد آخر مناسب";
                    break;

                case KhaledGuna2TextBox.ValidatingErrorEventArgs.enValidationErrorType.NotValidTextPhone:
                    errorMessage = "صيغة الهاتف غير صحيحة ,برجاء إدخال رقم آخر مناسب";
                    break;

                case KhaledGuna2TextBox.ValidatingErrorEventArgs.enValidationErrorType.NotValidDate:
                     errorMessage = "صيغة التاريخ غير صحيحة. الرجاء إدخال التاريخ بطريقة مناسبة مثل: " +
                       "1/2/25، 01/02/25، 1/2/2025، 01/02/2025، 1-2-25، 01-02-25، 1-2-2025، 01-02-2025";
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
