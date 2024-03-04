import React, { useState } from 'react'

export const useForm = () => {

  const [state, setState] = useState();

  const onChange = ( value, campo ) => {
    setState({
        ...state,
        [campo]: value
    })
  }


  return {
    ...state,
    formulario: state,
    onChange
  }
}
