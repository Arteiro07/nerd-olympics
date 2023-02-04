import style from './layout.module.scss'
import './layout.scss'
import { AiFillHome } from 'react-icons/ai';
import Link from "next/link";
import Image from 'next/image';
import logo from '../public/logo.svg'
export default function RootLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <html lang="en">
      <head />
      <body>
        <div className={style.container}>
          <div className={style.navigationBar}>
            <nav>
              <ul>
                <li>
                  <Image 
                    className={style.logo}
                    src={logo} 
                    alt="Logo" 
                    width={50}
                    height={50}
                  />
                </li>
                <li>
                  <Link href="/" > <AiFillHome/> </Link>
                </li>
                <li>
                  <Link href="/about">About </Link>
                </li>
                <li>
                  <Link href="/signup">Sign up</Link>
                </li>
                <li>
                  <Link href="/players">Players</Link>
                </li>
                <li>
                  <Link href="/competitions">Competitions</Link>
                </li>
              </ul>
            </nav>
          </div> 
          <div className={style.content}>
            {children}
          </div> 
        </div>
      </body>
    </html>
  )
}
