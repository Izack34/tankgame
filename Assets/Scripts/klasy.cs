using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class CIOModule
    {
        private char m_cModuleType;
        private int m_iNoInputs;
        private int iNoOutputs;
        
        public CIOModule(char m_cModuleTyperead ='A' ,
                         int m_iNoInputsread = 0 , int iNoOutputsread = 0)
        {
            
                
            m_cModuleType = m_cModuleTyperead;
            m_iNoInputs = m_iNoInputsread;
            iNoOutputs = iNoOutputsread;
        } 
        
        public void ModuleType(char m_cModuleTyperead ){
            m_cModuleType = m_cModuleTyperead;
        }
        
        public void NoInputs(char m_iNoInputsread ){
            m_iNoInputs = m_iNoInputsread;
        }
        
        public void NoOutputs(char iNoOutputsread ){
            iNoOutputs = iNoOutputsread;
        }
        
        public void show(){
            Console.WriteLine("typ " + m_cModuleType); 
            Console.WriteLine("inputy " + m_iNoInputs); 
            Console.WriteLine("output " + iNoOutputs); 
        }
    }
    
    public class CController
    {
        private string m_sControllerName;
        private CIOModule[] m_aModuleArray;
        
        public CController()
        {
            m_sControllerName = "";
            m_aModuleArray = new CIOModule[0];
            
        } 
        public CController(string m_sControllerNameRead )
        {
            m_sControllerName = m_sControllerNameRead;
            m_aModuleArray = new CIOModule[0];
            
        }
        
        
        public void ControllerName(string m_sControllerNameRead){
            m_sControllerName = m_sControllerNameRead;
        }
        
        public void ModuleArray(CIOModule m_aModuleArrayRead){
            Array.Resize(ref m_aModuleArray, m_aModuleArray.Length +1);
            m_aModuleArray[m_aModuleArray.Length - 1] = m_aModuleArrayRead;
            //m_aModuleArray =  m_aModuleArrayRead;
        }
        
        public void show(){
            Console.WriteLine("name " + m_sControllerName);
            
            foreach (CIOModule module in m_aModuleArray){
                Console.WriteLine(""); 
                module.show(); 
                
            }
                
        }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {

            CController obiekt1 = new CController("kontroler");
            
            CIOModule analog = new CIOModule('A', 2, 3);
            
            analog.show();
            obiekt1.ModuleArray(analog);
            
            CIOModule digit = new CIOModule('D', 3, 5);
            digit.show();
            
            obiekt1.ModuleArray(digit);
            
            Console.WriteLine(""); 
            
            obiekt1.show();
        }
    }
  
}