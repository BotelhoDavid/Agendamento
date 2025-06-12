using Agendamento.Domain.Core.Attributes;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;

namespace Agendamento.Domain.Core.Extensions
{
    public static class ExtensionMethods
    {

        /// <summary>
        /// Converte o objeto(s) para o tipo informado
        /// </summary>
        public static TType Deserialize<TType>(string serializedObject)
        {
            return JsonConvert.DeserializeObject<TType>(serializedObject);
        }

        /// <summary>
        /// Valida se classe possui alguma constante possui o valor informado no parâmetro {constantName}
        /// </summary>
        /// <typeparam name="T">Constante (exemplo OptionNivelCodigo)</typeparam>
        /// <param name="constantName">Constante a ser buscada (exemplo ASSNT existente em OptionNivelCodigo)</param>
        /// <returns>bool -> constante presente ou não</returns>
        public static bool ContainsConstant<T>(this T type, string constantName)
        {
            return Activator.CreateInstance(typeof(T)).GetType().GetAllPublicConstantValues<string>().Contains(constantName);
        }

        public static List<T> GetAllPublicConstantValues<T>(this Type type)
        {
            return type
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(fi => fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(T))
                .Select(x => (T)x.GetRawConstantValue())
                .ToList();
        }

        public static TService GetImplementation<TService, TImplementation>(this IServiceProvider serviceProvider) where TImplementation : TService
        {
            IEnumerable<TService> _implementations = serviceProvider.GetServices<TService>();
            return _implementations.FirstOrDefault(wh => wh.GetType() == typeof(TImplementation)) ??
                                    throw new NotImplementedException($"Nenhuma implementação encontrada para o tipo {typeof(TImplementation).Name}");
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> a, Expression<Func<T, bool>> b)
        {

            ParameterExpression p = a.Parameters[0];

            SubstExpressionVisitor visitor = new SubstExpressionVisitor { subst = { [b.Parameters[0]] = p } };

            Expression body = Expression.AndAlso(a.Body, visitor.Visit(b.Body));
            return Expression.Lambda<Func<T, bool>>(body, p);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> a, Expression<Func<T, bool>> b)
        {

            ParameterExpression p = a.Parameters[0];

            SubstExpressionVisitor visitor = new SubstExpressionVisitor { subst = { [b.Parameters[0]] = p } };

            Expression body = Expression.OrElse(a.Body, visitor.Visit(b.Body));
            return Expression.Lambda<Func<T, bool>>(body, p);
        }

        public static T Cast<T>(this Object model)
        {
            Type objectType = model.GetType();
            Type target = typeof(T);
            object ObjectInstance = Activator.CreateInstance(target, false);
            IEnumerable<MemberInfo> sourceMembers = from source in objectType.GetMembers().ToList()
                                                    where source.MemberType == MemberTypes.Property
                                                    select source;
            IEnumerable<MemberInfo> targetMembers = from source in target.GetMembers().ToList()
                                                    where source.MemberType == MemberTypes.Property
                                                    select source;
            List<MemberInfo> members = targetMembers.Where(memberInfo => targetMembers.Select(c => c.Name)
               .ToList().Contains(memberInfo.Name)).ToList();
            PropertyInfo propertyInfo;
            object value;
            foreach (var memberInfo in members)
            {
                propertyInfo = typeof(T).GetProperty(memberInfo.Name);
                if (model.GetType().GetProperty(memberInfo.Name) != null)
                {
                    value = model.GetType().GetProperty(memberInfo.Name).GetValue(model, null);

                    propertyInfo.SetValue(ObjectInstance, value, null);
                }
            }

            return (T)ObjectInstance;
        }
        private const string TokenTypeObject = "Object";
        private const string TokenTypeArray = "Array";

        /// <summary>
        /// Converter o objeto atual para JSON.
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="myObject"></param>
        /// <returns></returns>
        public static string ToJson<TType>(this TType myObject)
        {
            return JsonConvert.SerializeObject(myObject, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        /// <summary>
        /// Obter o valor Titulo da Annotation Description: [Description("Minha Descrição", "Meu titulo")]
        /// </summary>
        /// <typeparam name="TType">automaticamente obtido com o objeto.</typeparam>
        /// <param name="myEnum">objeto do tipo Enum.</param>
        /// <returns></returns>

        public static string GetTitle<TType>(this TType myEnum)
        {
            var _fieldInfo = myEnum.GetType().GetField(myEnum.ToString());

            var _customAttributes = (DescriptionAttribute[])_fieldInfo.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            return
                   _customAttributes != null && _customAttributes.Any()
                       ? _customAttributes[0].Title
                       : myEnum.ToString();
        }

        /// <summary>
        /// Obter o valor da Annotation Description: [Description("Minha Descrição")]
        /// </summary>
        /// <typeparam name="TType">automaticamente obtido com o objeto.</typeparam>
        /// <param name="myEnum">objeto do tipo Enum.</param>
        /// <returns></returns>

        public static string GetDescription<TType>(this TType myEnum)
        {
            System.Reflection.FieldInfo _fieldInfo = myEnum.GetType().GetField(myEnum.ToString());

            DescriptionAttribute[] _customAttributes = (DescriptionAttribute[])_fieldInfo.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            return
                   _customAttributes != null && _customAttributes.Any()
                       ? _customAttributes[0].Description
                       : myEnum.ToString();
        }

        /// <summary>
        /// Obter o valor da Annotation StatusCode: [StatusCode(500)]
        /// </summary>
        /// <typeparam name="TType">automaticamente obtido com o objeto.</typeparam>
        /// <param name="myEnum">objeto do tipo Enum.</param>
        /// <returns></returns>
        public static HttpStatusCode GetStatusCode<TType>(this TType myEnum)
        {
            var _fieldInfo = myEnum.GetType().GetField(myEnum.ToString());

            var _customAttributes = (HttpStatusCodeAttribute[])_fieldInfo.GetCustomAttributes(
                typeof(HttpStatusCodeAttribute), false);

            return
                   _customAttributes != null && _customAttributes.Any()
                       ? _customAttributes[0].HttpStatusCode
                       : HttpStatusCode.InternalServerError;
        }

        public static bool TryDeserializeJson<TType>(this object objToConvert, out TType resultParsed)
        {
            resultParsed = default(TType);

            try
            {
                if (!(objToConvert is string))
                    objToConvert = objToConvert.ToJson();

                resultParsed = JsonConvert.DeserializeObject<TType>(objToConvert as string);

                return resultParsed != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Obter os erros do ModelState separados por ponto e vírgula.
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static string GetAllErrorsToString(this ModelStateDictionary modelState)
        {
            IEnumerable<string> _errors = modelState?.Values.SelectMany(x => x?.Errors)
                            ?.Select(x => x?.ErrorMessage);

            return _errors != null && _errors.Any()
                        ? string.Join(" ", _errors)
                        : "Verifique os dados inseridos.";
        }

        /// <summary>
        /// Converte String para Objeto.
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public static dynamic ToObject(this string myString)
        {
            try
            {
                JToken token = JToken.Parse(myString);
                if (token.Type.ToString() == TokenTypeObject)
                {
                    JObject json = JObject.Parse(myString);
                    return json.ToObject<dynamic>();
                }
                else if (token.Type.ToString() == TokenTypeArray)
                {
                    JArray json = JArray.Parse(myString);
                    return json.ToObject<dynamic>();
                }
                else
                    return myString;
            }
            catch
            {
                return myString;
            }
        }
    }
}
