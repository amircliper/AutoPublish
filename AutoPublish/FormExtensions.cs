namespace AutoPublish;

public static class FormExtensions
{
    private static readonly Color BackColor = Color.FromArgb(30, 30, 30);
    private static readonly Color ForeColor = Color.FromArgb(220, 220, 220);
    private static readonly Color ControlBack = Color.FromArgb(45, 45, 48);
    private static readonly Color ButtonHover = Color.FromArgb(0, 122, 204);
    private static readonly Font DefaultFont = new Font("Segoe UI", 10);

    public static void ApplyModernTheme(this Form form)
    {
        form.BackColor = BackColor;
        form.ForeColor = ForeColor;
        form.Font = DefaultFont;

        ApplyThemeToControls(form.Controls);
    }

    private static void ApplyThemeToControls(Control.ControlCollection controls)
    {
        foreach (Control control in controls)
        {
            control.Font = DefaultFont;
            control.ForeColor = ForeColor;
            control.BackColor = (control is Panel or GroupBox) ? ControlBack : BackColor;

            switch (control)
            {
                case Button btn:
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatAppearance.MouseOverBackColor = ButtonHover;
                    btn.BackColor = ControlBack;
                    btn.ForeColor = ForeColor;
                    break;

                case TextBox txt:
                    txt.BorderStyle = BorderStyle.FixedSingle;
                    txt.BackColor = ControlBack;
                    txt.ForeColor = ForeColor;
                    break;

                case ComboBox cb:
                    cb.FlatStyle = FlatStyle.Flat;
                    cb.BackColor = ControlBack;
                    cb.ForeColor = ForeColor;
                    break;

                case DataGridView dgv:
                    dgv.BackgroundColor = ControlBack;
                    dgv.DefaultCellStyle.BackColor = ControlBack;
                    dgv.DefaultCellStyle.ForeColor = ForeColor;
                    dgv.DefaultCellStyle.SelectionBackColor = ButtonHover;
                    dgv.DefaultCellStyle.SelectionForeColor = Color.White;
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    break;
            }

            if (control.HasChildren)
                ApplyThemeToControls(control.Controls);
        }
    }
}