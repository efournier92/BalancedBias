using System;
using System.Collections.Generic;
using System.Web.UI;

public partial class BaseArticleTemplates : UserControl
{
    public string ArticleTemplateType { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        HideUnusedTemplates();
    }

    private void HideUnusedTemplates()
    {
        var knownTemplateTypes = new List<string>();
        knownTemplateTypes.Add("Generic");
        knownTemplateTypes.Add("Trump");
        foreach (var control in this.Controls)
        {
            //control.Visible = false;
        }

        foreach (var templateType in knownTemplateTypes)
        {
            if (ArticleTemplateType == templateType)
            {
                //TemplateGeneric.Visible = false;

            }
        }

        //throw new NotImplementedException();
    }
}

 