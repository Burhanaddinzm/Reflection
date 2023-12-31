﻿using Reflection;
using System.Reflection;

//Reflection
#region 1ci

////GetType(); Type class in'dan obyekt
//Student student = new Student();
//Type type = student.GetType();

////Property
//PropertyInfo[] properties = type.GetProperties();

//Console.WriteLine("|Properties|\n");
//foreach (PropertyInfo property in properties)
//{
//    Console.WriteLine(property.Name);
//}

////Field
//FieldInfo[] fieldInfos1 = type.GetFields();

//FieldInfo[] fieldInfos2 = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

//Console.WriteLine("\n|Fields|\n");

////Tek field gosterir-----------------------------------------------------------------------

//FieldInfo? result = type.GetField("Avg", BindingFlags.NonPublic | BindingFlags.Instance);

//Console.WriteLine(result.GetValue(student));
//result.SetValue(student, "Newest Value");
//Console.WriteLine(result.GetValue(student));
////------------------------------------------

//foreach (FieldInfo fieldInfo in fieldInfos1)
//{
//    Console.WriteLine(fieldInfo.Name);
//}

////Private fieldlari cixardir----------------
//foreach (FieldInfo fieldInfo in fieldInfos2)
//{
//    //Private field'in deyerini gosterir
//    object? result1 = fieldInfo.GetValue(student);
//    Console.WriteLine(result1);
//    //Private fielda'a yeni deyer teyin edir
//    fieldInfo.SetValue(student, "New Value");
//    object? result2 = fieldInfo.GetValue(student);
//    Console.WriteLine(result2);

//    //-------------------------------
//    Console.WriteLine(fieldInfo.Name);
//}

////Method
//MethodInfo[] methodInfo = type.GetMethods();

//Console.WriteLine("\n|Methods|\n");
//foreach (MethodInfo method in methodInfo)
//{
//    Console.WriteLine(method.Name);
//}

#endregion

#region 2ci

////Student dolu
//Student student = new Student()
//{
//    Name = "Test",
//    Surname = "Test"
//};
////Teacher bos
//Teacher teacher = new Teacher();

//Mapping();
//Console.WriteLine(teacher.Name + " " + teacher.Surname);

//void Mapping()
//{
//    var studentProperties = student.GetType().GetProperties();

//    foreach (var item in studentProperties)
//    {
//        var propName = item.Name;
//        var value = item.GetValue(student);
//        var teacherProp = teacher.GetType().GetProperty(propName);
//        if (teacherProp != null)
//        {
//            teacherProp.SetValue(teacher, value);
//        }
//    }
//}

#endregion

#region 2nin generic versiyasi

Student student = new Student()
{
    Name = "Test",
    Surname = "Test"
};

Teacher teacher = new Teacher();

Mapping<Student, Teacher>(student, teacher);

Console.WriteLine(teacher.Name + " " + teacher.Surname);

void Mapping<Tfrom, Tto>(Tfrom tfrom, Tto tto)
{
    var properties1 = tfrom.GetType().GetProperties();

    foreach (var item in properties1)
    {
        var propName = item.Name;
        var value = item.GetValue(student);
        var properties2 = tto.GetType().GetProperty(propName);
        if (properties2 != null)
        {
            properties2.SetValue(tto, value);
        }
    }
}
#endregion