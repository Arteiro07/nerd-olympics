"use client";

import { FC, useRef, useState } from "react";
import style from "./modalContainer.module.scss";
import { AiOutlineCloseCircle } from "react-icons/ai";
interface ModalProps {
	display: boolean;
	close: () => void;
	children: React.ReactNode;
}

const Modal: FC<ModalProps> = ({ display, close, children }) => (
	<div className={style.modalContainer}>
		<div className={style.modalOverlay} onClick={close} />
		<div className={style.modalBox}>
			<button className={style.modalClose} type="button" onClick={close}>
				<AiOutlineCloseCircle />
			</button>
			{children}
		</div>
	</div>
);
export default Modal;
