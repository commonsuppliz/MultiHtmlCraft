using System;

namespace MultiHtmlCraft.Interfaces
{
    public interface ICommonObjectInterface
    {

        void ___setPropertyByName(string name, object val);
        void ___setPropertyByIndex(int ___index, object val);
        object ___getPropertyByName(string name);
        object ___getPropertyByIndex(int ___index);
        bool ___hasPropertyByName(string name);
        bool ___hasPropertyByIndex(int ___index);
        void ___deleteByIndex(int ___index);
        void ___deleteByName(string ___Name);
        object[] ___getByIds();
        object ___getDefaultValue();
        object ___getProtoType();
        void ___setProtoType(object __object);
        void ___setParentScope(object __object);
        object ___getParentScope();
        string ___getClassName();
        bool ___hasInstance(object __object);
        bool ___instanceEquals(object __object);
        object ___common_object_clone();
        IMutilversalObjectType multiversalClassType
        {
            get;
        }
    }
}
