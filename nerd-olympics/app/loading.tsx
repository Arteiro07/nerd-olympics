import style from './loading.module.scss'

export default function BaseLoading() {
  return( 
  <>
    <div className={style.container}>

        <div className={style.loader}></div> 
    </div>
  </>
  )
}