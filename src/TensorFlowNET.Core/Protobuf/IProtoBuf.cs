﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tensorflow
{
    /// <summary>
    /// In order for a object to be serialized to and from MetaGraphDef, 
    /// the class must implement to_proto() and from_proto() methods
    /// </summary>
    public interface IProtoBuf
    {
        string name { get; }

        /// <summary>
        /// Converts a `Variable` to a `VariableDef` protocol buffer.
        /// </summary>
        /// <param name="export_scope"></param>
        /// <returns></returns>
        VariableDef to_proto(string export_scope);

        /// <summary>
        /// Returns a `Variable` object created from `variable_def`.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="variable_def"></param>
        /// <param name="import_scope"></param>
        /// <returns></returns>
        T from_proto<T>(VariableDef variable_def, string import_scope);
    }
}
