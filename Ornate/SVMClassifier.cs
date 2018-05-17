using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibSVMsharp;
using LibSVMsharp.Helpers;

namespace Ornate
{
    class SVMClassifier
    {
        public String trainingDataSetPath { get; set; }
        public String classificationSetPath {get;set;}
        public SVMClassifier()
        {

            SVMProblem problem = SVMProblemHelper.Load(@"dataset_path.txt");
            SVMProblem testProblem = SVMProblemHelper.Load(@"test_dataset_path.txt");

            SVMParameter parameter = new SVMParameter();
            parameter.Type = SVMType.C_SVC;
            parameter.Kernel = SVMKernelType.RBF;
            parameter.C = 1;
            parameter.Gamma = 1;

            SVMModel model = SVM.Train(problem, parameter);

            double[] target = new double[testProblem.Length];
            for (int i = 0; i < testProblem.Length; i++)
                target[i] = SVM.Predict(model, testProblem.X[i]);

            double accuracy = SVMHelper.EvaluateClassificationProblem(testProblem, target);
        }


    }

       
 
}
