﻿namespace Framework.Web.Forms
{
    public interface IFormHandlerFactory
    {
        IFormHandler<TForm> Create<TForm>() where TForm : IForm;
    }
}