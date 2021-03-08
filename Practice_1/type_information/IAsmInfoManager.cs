
namespace type_information
{
    interface IAsmInfoManager<T> where T : class
    {
        T Asm_info_storage { get; }
        int refAssemblies { get; }
        int types_Of_current_asm { get; }
        int refTypes { get; }
        int valueTypes {get;}
        int interfaceTypes {get;}
        string type_with_max_methods {get;}
        string max_name {get;}
        string max_args {get;}
        T Initial_Asm_info_storage();
    }
}