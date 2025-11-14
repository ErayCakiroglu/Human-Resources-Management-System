namespace HRMS.Business.Helper.Abstract
{
    public interface ICodeGenerator<T>
    {
        string GenerateCode(T TDto);
    }
}
