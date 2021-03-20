using System.Collections.Generic;

namespace Architecture.Utility
{
    public interface IResponse
    {
        List<Error> Errors { get; set; }

        bool DidError { get; }
    }

    public interface ISingleResponse<TModel> : IResponse
    {
        TModel Result { get; set; }
    }

    public interface IListResponse<TModel> : IResponse
    {
        IEnumerable<TModel> Result { get; set; }
    }

    public interface IPagedResponse<TModel> : IListResponse<TModel>
    {
        int ItemsCount { get; set; }

        int PageCount { get; }
    }

    public class Response : IResponse
    {
        private List<Error> errors = new List<Error>();
        public List<Error> Errors { get { return errors; } set { value = errors; } }

        public bool DidError { get; }
    }

    public class SingleResponse<TModel> : ISingleResponse<TModel>
    {
        public bool DidError => errors.Count > 0 ? true : false;

        private List<Error> errors = new List<Error>();
        public List<Error> Errors { get { return errors; } set { value = errors; } }
        public TModel Result { get; set; }
    }

    public class ListResponse<TModel> : IListResponse<TModel>
    {
        public string Message { get; set; }

        public bool DidError => errors.Count > 0 ? true : false;

        private List<Error> errors = new List<Error>();
        public List<Error> Errors { get { return errors; } set { value = errors; } }
        public IEnumerable<TModel> Result { get; set; }

        public int ItemsCount { get; set; }
    }

    public class PagedResponse<TModel> : IPagedResponse<TModel>
    {
        public bool DidError => errors.Count > 0 ? true : false;
        private List<Error> errors = new List<Error>();
        public List<Error> Errors { get { return errors; } set { value = errors; } }
        public IEnumerable<TModel> Result { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public int ItemsCount { get; set; }

        public int PageCount => ItemsCount < PageSize ? 1 : (int)(((double)ItemsCount / PageSize) + 1);
    }

    public class Error
    {
        public string ErrorCode { get; set; }

        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}