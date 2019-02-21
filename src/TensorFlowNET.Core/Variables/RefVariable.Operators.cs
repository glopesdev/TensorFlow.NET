﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tensorflow
{
    public partial class RefVariable
    {
        public static Tensor operator +(RefVariable x, int y) => op_helper("add", x, y);
        public static Tensor operator +(RefVariable x, float y) => op_helper("add", x, y);
        public static Tensor operator +(RefVariable x, double y) => op_helper("add", x, y);
        
        public static Tensor operator -(RefVariable x, int y) => op_helper("sub", x, y);
        public static Tensor operator -(RefVariable x, float y) => op_helper("sub", x, y);
        public static Tensor operator -(RefVariable x, double y) => op_helper("sub", x, y);
        
        private static Tensor op_helper<T>(string default_name, RefVariable x, T y)
        {
            var tensor1 = x.value();
            return Python.with<ops.name_scope, Tensor>(new ops.name_scope(null, default_name, new object[] { tensor1, y }), scope => {
                var tensor2 = ops.convert_to_tensor(y, tensor1.dtype.as_base_dtype(), "y");
                return gen_math_ops.add(tensor1, tensor2, scope);
            });
        }
    }
}
