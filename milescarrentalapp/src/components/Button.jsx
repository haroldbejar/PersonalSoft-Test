import React from 'react'

export const Button = ( { btnType, btnClass, btnText, ...props } ) => {

  return (
    <button type={btnType} className={btnClass} {...props}>
      {btnText}
    </button>
  );
}
