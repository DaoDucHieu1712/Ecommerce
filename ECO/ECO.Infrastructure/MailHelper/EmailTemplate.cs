using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Infrastructure.MailHelper
{
    public class EmailTemplate
    {
    }
    public class EmailTemplateSubjectConstant
    {

        public const string ResetPasswordSubject = "Yêu cầu Đặt lại Mật khẩu";
        public const string ConfirmEmailBody = "Xác nhận Email";

    }

    public class EmailTemplateBodyConstant
    {
        public const string ResetPasswordBody = @"<p>Xin chào,</p>
                                                    <p>Chúng tôi đã nhận được yêu cầu đặt lại mật khẩu cho tài khoản của bạn liên kết với địa chỉ email:
                                                    <strong>{0}</strong></p>
                                                    <p>Để đặt lại mật khẩu của bạn, vui lòng nhấp vào liên kết sau đây:</p>
                                                    <p><a href=""{1}"">Đặt lại Mật khẩu</a></p>
                                                    <p>Nếu bạn không thực hiện yêu cầu này, vui lòng bỏ qua email này. Không có thay đổi nào sẽ được thực hiện đối với tài khoản của bạn.</p>
                                                    <p>Liên kết này sẽ hết hạn sau một thời gian nhất định, vui lòng đặt lại mật khẩu trong khoảng thời gian đó.</p>
                                                    ";

        public const string SignatureFooter = @"<p>Cảm ơn bạn đã sử dụng dịch vụ của chúng tôi!</p>
                                                <p>Email này được gửi tự động, <em><strong>vui lòng không trả lời</strong></em>.</p>
                                                <p>&nbsp;</p>
                                                <p><em><strong>Trân trọng,</strong></em></p>
                                                <p>&nbsp;<em><strong>ECO DEGREY SHOP </strong></em></p>
                                                <p><span style=""color: #3366ff;""><em>ECO DEMO</em></span></p>
                                                <p><span style=""color: #3366ff;""><em>Đại Thịnh - Mê Linh - Hà Nội</em></span></p>
                                                <p><strong><em>CHÚC BẠN CÓ TRẢI NGHIỆM TỐT!</em></strong></p>
                                                ";

        public const string ConfirmEmailBody = @"<p>Xin chào,
                                                    <strong>{0}</strong></p>
                                                    <p>Để xác nhận email của bạn, vui lòng nhấp vào liên kết sau đây:</p>
                                                    <p><a href=""{1}"">here</a></p>";
                                                   
    }
}
