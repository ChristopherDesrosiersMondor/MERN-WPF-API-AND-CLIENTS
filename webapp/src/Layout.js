import { Outlet } from "react-router-dom";
import Header from "./Views/_header";

export default function Layout() {
    return (
        <main>
            <Header />
            <Outlet />
        </main>
    );
}