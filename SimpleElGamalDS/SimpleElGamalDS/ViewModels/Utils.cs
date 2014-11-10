using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleElGamalDS.ViewModels
{
    static class Utils
    {
        public static void SaveKeyToFileWithDialog(string str, bool isOpenKey)
        {
            Stream stream;

            SaveFileDialog dialog = new SaveFileDialog();

            if (isOpenKey)
                dialog.Filter = "Файлы открытых ключей |*.openkey";
            else
                dialog.Filter = "Файлы закрытых ключей |*.privatekey";
            
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if ((stream = dialog.OpenFile()) != null)
                {
                    var bytes = Encoding.Default.GetBytes(str);
                    stream.Write(bytes, 0, bytes.GetLength(0));
                    stream.Close();
                    MessageBox.Show("Cохранено в файл " + dialog.FileName);
                }
            }
        }

        public static string ReadPrivateKeyFromFileWithDialog()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Файлы закрытых ключей |*.privatekey";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if(dialog.FileName != null)
                    {
                        return File.ReadAllText(dialog.FileName,Encoding.Default);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return null;
        }

        public static Tuple<string,string> ReadFileWithDialog()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (dialog.FileName != null)
                    {
                        return new Tuple<string, string>(File.ReadAllText(dialog.FileName, Encoding.Default), dialog.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return null;
        }


        public static string ReadOpenKeyFromFileWithDialog()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Файлы открытых ключей |*.openkey";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (dialog.FileName != null)
                    {
                        return File.ReadAllText(dialog.FileName, Encoding.Default);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return null;
        }

        public static void SaveSignatureWithDialog(byte[] signature, string filePath)
        {
            var path = Path.GetDirectoryName(filePath);
            var fileName = Path.GetFileNameWithoutExtension(filePath);
            var resultPath = path + "\\" + fileName + ".egsign";

            File.WriteAllBytes(resultPath, signature);
            MessageBox.Show("Cохранено в файл " + resultPath);               
        }

        public static byte[] ReadSignatureWithDialog()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Файлы ЭЦП |*.egsign";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (dialog.FileName != null)
                    {
                        return File.ReadAllBytes(dialog.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return null;
        }
    }
}
