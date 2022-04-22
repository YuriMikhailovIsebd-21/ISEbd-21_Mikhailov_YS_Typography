using TypographyBusinessLogic.OfficePackage.HelperEnums;
using TypographyBusinessLogic.OfficePackage.HelperModels;
using System.Collections.Generic;

namespace TypographyBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToWord
    {
        public void CreateDoc(WordInfo info)
        {
            CreateWord(info);

            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)>
                {(
                info.Title, new WordTextProperties
                {
                    Bold = true, Size = "24",
                }
                )},
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });

            foreach (var printed in info.Printeds)
            {
                CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)>
                    {
                        (printed.PrintedName + ": ", new WordTextProperties { Size = "24", Bold = true }),
                        (printed.Price.ToString(), new WordTextProperties { Size = "24", Bold = false })
                    },
                    TextProperties = new WordTextProperties
                    {
                        Size = "24",
                        JustificationType = WordJustificationType.Both
                    }
                });
            }

            SaveWord(info);
        }

        protected abstract void CreateWord(WordInfo info);

        protected abstract void CreateParagraph(WordParagraph paragraph);

        protected abstract void SaveWord(WordInfo info);
    }
}
