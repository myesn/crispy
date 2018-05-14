namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class CrispyConstants
    {
        public static class ModelRules
        {
            public static class Application
            {
                public const string TableName = "Applications";
                public const int NameMaxLength = 50;
            }

            public static class Variable
            {
                public const string TableName = "Variables";
                public const int KeyMaxLength = 50;
                public const int ValueMaxLength = 1280;//256 * 5
            }

            public static class Environment
            {
                public const string TableName = "Environments";
                public const int NameMaxLength = 50;
            }

            public static class KeyValuePair
            {
                public const string TableName = "KeyValuePairs";
                public const int KeyMaxLength = 50;
                public const int ValueMaxLength = 1280;//256 * 5;
                public const int DescriptionMaxLength = 256;
            }

            public static class KeyValuePairHistory
            {
                public const string TableName = "KeyValuePairHistories";
                public const int ValueMaxLength = KeyValuePair.ValueMaxLength;
            }
        }


    }
}
