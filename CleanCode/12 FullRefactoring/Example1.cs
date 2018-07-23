using CleanCode._12_FullRefactoring;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI.WebControls;

namespace Project.UserControls
{
    public class PostControl : System.Web.UI.UserControl
    {
        private readonly PostValidator _validator;
        private readonly PostRepository _postRepository;

        public PostControl()
        {
            _validator = new PostValidator();
            _postRepository = new PostRepository();
        }

        public void ShowErrors(ValidationResult results)
        {
            BulletedList summary = (BulletedList)FindControl("ErrorSummary");
            foreach (var failure in results.Errors)
            {
                Label errorMessage = FindControl(failure.PropertyName + "Error") as Label;

                if (errorMessage == null)
                {
                    summary.Items.Add(new ListItem(failure.ErrorMessage));
                }
                else
                {
                    errorMessage.Text = failure.ErrorMessage;
                }
            }
        }

        public void TryToSave()
        {
            Post entity = new Post()
            {
                Id = Convert.ToInt32(PostId.Value),
                Title = PostTitle.Text.Trim(),
                Body = PostBody.Text.Trim()
            };

            ValidationResult results = _validator.Validate(entity);

            if (results.IsValid)
                _postRepository.Save(entity);
            else
                ShowErrors(results);
        }

        public void ShowForm(Post entity)
        {
            PostBody.Text = entity.Body;
            PostTitle.Text = entity.Title;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                TryToSave();
            else
                ShowForm(_postRepository.GetById(Convert.ToInt32(Request.QueryString["id"])));
        }

        public Label PostBody { get; set; }

        public Label PostTitle { get; set; }

        public int? PostId { get; set; }
    }

    #region helpers

    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public IEnumerable<ValidationError> Errors { get; set; }
    }

    public class ValidationError
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class PostValidator
    {
        public ValidationResult Validate(Post entity)
        {
            throw new NotImplementedException();
        }
    }  
    #endregion

}